﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;

namespace PruebaApiSpa.EntityFrameworkCore.Seed.Host
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

        private readonly PruebaApiSpaDbContext _context;

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            var tenantId = PruebaApiSpaConsts.MultiTenancyEnabled ? null : (int?)MultiTenancyConsts.DefaultTenantId;
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(tenantId, "en", "English", "famfamfam-flags us")
            };
        }

        public DefaultLanguagesCreator(PruebaApiSpaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
