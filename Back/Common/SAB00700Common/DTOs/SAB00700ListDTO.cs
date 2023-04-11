using R_APICommonDTO;
using System.Collections.Generic;

namespace SAB00700Common.DTOs
{
    public class SAB00700ListDTO : R_APIResultBaseDTO
    {
        public List<SAB00700DTO> Data { get; set; }
    }
}
