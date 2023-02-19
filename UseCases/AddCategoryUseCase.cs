﻿using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class AddCategoryUseCase : IAddCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public AddCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Execute(Category category)
    {
        _categoryRepository.AddCategory(category);
    }
}