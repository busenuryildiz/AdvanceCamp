using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand :IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }
        public class CreatedBrandCommandHandler:IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
           private readonly IBrandRepository _brandRepository;
           private readonly IMapper _mapper;

           public CreatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
           {
               _brandRepository = brandRepository;
               _mapper = mapper;
           }

           public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
           {
               Brand mappedBrand = _mapper.Map<Brand>(request);
               Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
               CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);
              
               return createdBrandDto;
           }
        }

    }
}
