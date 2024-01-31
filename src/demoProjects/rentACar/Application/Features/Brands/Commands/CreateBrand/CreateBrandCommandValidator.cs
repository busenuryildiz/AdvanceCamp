﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
