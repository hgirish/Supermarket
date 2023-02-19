﻿using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases;

public class DeleteCategoryUseCase : IDeleteCategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryUseCase(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public void Execute(int categoryId)
    {
        _categoryRepository.DeleteCategory(categoryId);
    }
}