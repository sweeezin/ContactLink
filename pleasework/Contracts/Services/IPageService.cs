﻿using System.Windows.Controls;

namespace pleasework.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
