﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Dto
{
    public class BankAccountDto
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Bank { get; set; }
        public string Token { get; set; }
    }
}
