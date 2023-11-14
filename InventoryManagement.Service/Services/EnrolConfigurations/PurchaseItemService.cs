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

public class PurchaseItemService : BaseService<PurchaseItem>, IPurchaseItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public PurchaseItemService(IUnitOfWork unitOfWork,
        IMapper mapper,
        IWebHostEnvironment webHostEnvironment,
        IOptions<AppSettings> appSettings) : base(unitOfWork)
    {
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<Paging<PurchaseItemModel>> GetSearchAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string searchText = null)
    {
        var data = await _unitOfWork.Repository<PurchaseItem>().GetPageAsync(pageIndex,
            pageSize,
            s => (string.IsNullOrEmpty(searchText) || s.BatchNumber.Contains(searchText)),
            o => o.OrderBy(ob => ob.Id),
            se => se,
            p => p.Purchase,
            q => q.Item
        );

        var response = data.ToPagingModel<PurchaseItem, PurchaseItemModel>(_mapper);

        return response;
    }
    public async Task<Paging<PurchaseItemModel>> GetFilterAsync(int pageIndex = CommonVariables.pageIndex, int pageSize = CommonVariables.pageSize, string filterText1 = null)
    {
        var data = await _unitOfWork.Repository<PurchaseItem>().GetPageAsync(pageIndex,
            pageSize,
            s => ((string.IsNullOrEmpty(filterText1) || s.BatchNumber.Contains(filterText1))),

            o => o.OrderBy(ob => ob.Id),
            se => se,
            p => p.Purchase,
            q => q.Item
        );

        var response = data.ToPagingModel<PurchaseItem, PurchaseItemModel>(_mapper);

        return response;
    }
    public async Task<PurchaseItemModel> GetPurchaseItemDetailAsync(long purchaseDetailsId)
    {
        var data = await _unitOfWork.Repository<PurchaseItem>().FirstOrDefaultAsync(f => f.Id == purchaseDetailsId,
            o => o.OrderBy(ob => ob.Id),
            p => p.Purchase,
            q => q.Item);


        var response = _mapper.Map<PurchaseItem, PurchaseItemModel>(data);

        return response;
    }
    public async Task<PurchaseItemModel> AddPurchaseItemDetailAsync(PurchaseItemModel purchaseDetails)
    {


        var entity = _mapper.Map<PurchaseItemModel, PurchaseItem>(purchaseDetails);

        await _unitOfWork.Repository<PurchaseItem>().UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseItemModel();
    }
    public async Task<PurchaseItemModel> UpdatePurchaseItemDetailAsync(long purchaseDetailsId, PurchaseItemModel purchaseDetails)
    {
        var entity = _mapper.Map<PurchaseItemModel, PurchaseItem>(purchaseDetails);

        await _unitOfWork.Repository<PurchaseItem>().UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseItemModel();
    }
    public async Task<PurchaseItemModel> UpdatePurchaseItemDetailAsync(long purchaseDetailsId, string model)
    {
        var purchaseDetails = JsonConvert.DeserializeObject<PurchaseItemModel>(model);
        var entity = _mapper.Map<PurchaseItemModel, PurchaseItem>(purchaseDetails);

        await _unitOfWork.Repository<PurchaseItem>().UpdateAsync(entity);
        await _unitOfWork.CompleteAsync();

        return new PurchaseItemModel();
    }
    public async Task<Dropdown<PurchaseItemModel>> GetDropdownAsync(string searchText = null,
        int size = CommonVariables.DropdownSize)
    {
        var data = await _unitOfWork.Repository<PurchaseItem>().GetDropdownAsync(
            p => (string.IsNullOrEmpty(searchText) || p.BatchNumber.Contains(searchText)),
            o => o.OrderBy(ob => ob.Id),
            se => new PurchaseItemModel { Id = se.Id, BatchNumber = se.BatchNumber },
            size);

        return data;
    }

    public async Task<PurchaseItemModel> DeletePurchaseItemDetailAsync(long purchaseDetailsId)
    {       
        await _unitOfWork.Repository<PurchaseItem>().DeleteAsync(purchaseDetailsId);
        await _unitOfWork.CompleteAsync();

        return new PurchaseItemModel();
    }
}