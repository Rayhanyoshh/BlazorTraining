using R_BlazorFrontEnd;
using R_BlazorFrontEnd.Enums;
using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00700Common.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SAB00700Model
{
    public class SAB00700ViewModel : R_ViewModel<SAB00700DTO>
    {
        private SAB00700Model _model = null;

        public SAB00700ViewModel()
        {
            _model = new SAB00700Model();
        }

        public ObservableCollection<SAB00700DTO> CategoryList = new ObservableCollection<SAB00700DTO>();

        public async Task GetCategoryList()
        {
            var loEx = new R_Exception();

            try
            {
                var loResult = await _model.GetCategoryListAsync();
                CategoryList = new ObservableCollection<SAB00700DTO>(loResult);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<SAB00700DTO> GetCategoryById(int piCategoryId)
        {
            var loEx = new R_Exception();
            SAB00700DTO loResult = null;

            try
            {
                var loParam = new SAB00700DTO { CategoryID = piCategoryId };
                loResult = await _model.GetCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB00700DTO> SaveCategory(SAB00700DTO newEntity, R_eConductorMode conductorMode)
        {
            var loEx = new R_Exception();
            SAB00700DTO loResult = null;

            try
            {
                loResult = await _model.SaveCategoryAsync(newEntity, (eCRUDMode)conductorMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCategory(int piCategoryId)
        {
            var loEx = new R_Exception();

            try
            {
                var loParam = new SAB00700DTO { CategoryID = piCategoryId };
                await _model.DeleteCategoryAsync(loParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }
    }
}
