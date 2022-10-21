using System;

namespace Velar.Core.ViewModels
{
    public class UserTokenViewModel
    {
        public string FirstName { get; set; } = null!;
        public Uri ActionUri { get; set; } = null!;
        public Uri BaseUri { get; set; } = null!;
    }
}