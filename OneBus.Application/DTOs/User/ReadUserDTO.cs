﻿namespace OneBus.Application.DTOs.User
{
    public class ReadUserDTO : BaseReadDTO
    {
        public ReadUserDTO()
        {
            Email = string.Empty;
        }

        public string Email { get; set; }

        public ulong CompanyId { get; set; }
    }
}
