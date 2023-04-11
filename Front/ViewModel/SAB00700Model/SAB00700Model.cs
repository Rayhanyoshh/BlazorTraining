using R_BlazorFrontEnd.Exceptions;
using R_CommonFrontBackAPI;
using SAB00700Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SAB00700Model
{
    public class SAB00700Model
    {
        private SAB00700Client _clientWrapper = null;

        public SAB00700Model()
        {
            _clientWrapper = new SAB00700Client();
        }

        public async Task<SAB00700DTO> GetCategoryAsync(SAB00700DTO poParam)
        {
            var loEx = new R_Exception();
            SAB00700DTO loResult = null;

            try
            {
                loResult = await _clientWrapper.R_ServiceGetRecordAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task<SAB00700DTO> SaveCategoryAsync(SAB00700DTO poParam, eCRUDMode poCRUDMode)
        {
            var loEx = new R_Exception();
            SAB00700DTO loResult = null;

            try
            {
                loResult = await _clientWrapper.R_ServiceSaveAsync(poParam, poCRUDMode);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }

        public async Task DeleteCategoryAsync(SAB00700DTO poParam)
        {
            var loEx = new R_Exception();

            try
            {
                await _clientWrapper.R_ServiceDeleteAsync(poParam);
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();
        }

        public async Task<List<SAB00700DTO>> GetCategoryListAsync()
        {
            var loEx = new R_Exception();
            List<SAB00700DTO> loResult = null;

            try
            {
                var loCategories = await _clientWrapper.GetAllCategoryAsync();
                loResult = loCategories.Data;
            }
            catch (Exception ex)
            {
                loEx.Add(ex);
            }

            loEx.ThrowExceptionIfErrors();

            return loResult;
        }
    }
}