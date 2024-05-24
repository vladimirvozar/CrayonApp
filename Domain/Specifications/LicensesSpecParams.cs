﻿namespace Domain.Specifications
{
    public class LicensesSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; 
        }

        public string Sort { get; set; }

        private string _softwareProductCode;
        public string SoftwareProductCode
        {
            get => _softwareProductCode;
            set => _softwareProductCode = value.ToLower();
        }
    }
}
