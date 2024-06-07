using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManager.Models;
using TaskManager.Models.Context;
using TaskManager.Models.DbModel;
using TaskManager.Models.Dto;

namespace TaskManager.Models.Dto
{
    public class FilterDto
    {
        public bool Overdue { get; set; }
        public bool Intime { get; set; }
        public string OrderBy { get; set; }
        public string OrderType { get; set; }
    }
}
