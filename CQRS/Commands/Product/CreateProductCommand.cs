﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.Commands.Product
{
    public class CreateProductCommand:IRequest<Entities.Product>
    {
        public Entities.Product Product { get; set; }
    }
}
