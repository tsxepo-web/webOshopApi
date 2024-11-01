using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace webOshop.Application.Commands;
public record DeleteProductCommand(string ProductId) : IRequest<bool>;