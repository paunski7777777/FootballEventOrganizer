﻿namespace Footeo.Web.Controllers
{
    using Footeo.Services.Contracts;
    using Footeo.Web.Controllers.Base;
    using Footeo.Web.ViewModels.Fields.View;
    
    using Microsoft.AspNetCore.Mvc;

    using System.Linq;

    public class FieldsController : BaseController
    {
        private readonly IFieldsService fieldsService;

        public FieldsController(IFieldsService fieldsService)
        {
            this.fieldsService = fieldsService;
        }

        public IActionResult All()
        {
            var fields = this.fieldsService
                              .All()
                              .Select(vm => new FieldViewModel
                              {
                                  Name = vm.Name,
                                  Address = vm.Address,
                                  IsIndoors = vm.IsIndoors,
                                  Town = vm.Town.Name
                              })
                              .ToList();

            var fieldViewModels = new AllFieldsViewModel
            {
                Fields = fields
            };

            return View(fieldViewModels);
        }
    }
}