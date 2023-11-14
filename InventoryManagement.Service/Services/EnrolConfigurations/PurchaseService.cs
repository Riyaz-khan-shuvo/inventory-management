using AutoMapper;
using InventoryManagement.Core;
using InventoryManagement.Core.Collections;
using InventoryManagement.Service.Models.Enrols;
using InventoryManagement.Service.Services.Base;
using InventoryManagement.Sql.Entities.Enrols;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Services.EnrolConfigurations;

public class PurchaseService : BaseService<Purchase>, IPurchaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public PurchaseService(IUnitOfWork unitOfWork,
        IMapper mapper,
        IWebHostEnvironment webHostEnvironment,
        IOptions<AppSettings> appSettings) : base(unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<Paging<PurchaseModel>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var data = await _unitOfWork.Repository<Purchase>().GetPageAsync(pageIndex,
            pageSize,
            s => string.IsNullOrEmpty(searchText) || s.PurchasesCode.Contains(searchText),
            o => o.OrderBy(ob => ob.Id),
            se => se,
            i => i.User,
            p => p.Supplier,
            q => q.Company,
            q => q.PurchaseItems
            );

        var response = data.ToPagingModel<Purchase, PurchaseModel>(_mapper);

        return response;
    }
    public async Task<Paging<PurchaseModel>> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null)
    {
        var data = await _unitOfWork.Repository<Purchase>().GetPageAsync(pageIndex,
            pageSize,
            s => string.IsNullOrEmpty(filterText1) || s.PurchasesCode.Contains(filterText1),

            o => o.OrderBy(ob => ob.Id),
            se => se,
            i => i.User, p => p.Supplier, q => q.Company);

        var response = data.ToPagingModel<Purchase, PurchaseModel>(_mapper);

        return response;
    }
    public async Task<PurchaseModel> GetPurchaseDetailAsync(long purchasesMasterId)
    {
        var data = await _unitOfWork.Repository<Purchase>().FirstOrDefaultAsync(f => f.Id == purchasesMasterId,
            o => o.OrderBy(ob => ob.Id),
            i => i.User,
            p => p.Supplier,
            q => q.Company,
            q => q.PurchaseItems
            );


        var response = _mapper.Map<Purchase, PurchaseModel>(data);

        return response;
    }
    public async Task<PurchaseModel> AddPurchaseDetailAsync(PurchaseModel purchase)
    {
        var entity = _mapper.Map<PurchaseModel, Purchase>(purchase);

        await _unitOfWork.Repository<Purchase>().InsertAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseModel();
    }
    public async Task<PurchaseModel> UpdatePurchaseDetailAsync(long purchasesMasterId, PurchaseModel purchase)
    {
        var entity = _mapper.Map<PurchaseModel, Purchase>(purchase);

        await _unitOfWork.Repository<Purchase>().UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseModel();
    }
    public async Task<PurchaseModel> UpdatePurchaseDetailAsync(long purchasesMasterId, string model)
    {
        var purchase = JsonConvert.DeserializeObject<PurchaseModel>(model);
        var entity = _mapper.Map<PurchaseModel, Purchase>(purchase);

        await _unitOfWork.Repository<Purchase>().UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseModel();
    }
    public async Task<Dropdown<PurchaseModel>> GetDropdownAsync(string searchText = null,
        int size = CommonVariables.DropdownSize)
    {
        var data = await _unitOfWork.Repository<Purchase>().GetDropdownAsync(
            p => string.IsNullOrEmpty(searchText) || p.PurchasesCode.Contains(searchText),
            o => o.OrderBy(ob => ob.Id),
            se => new PurchaseModel { Id = se.Id, PurchasesCode = se.PurchasesCode },
            size);

        return data;
    }
}