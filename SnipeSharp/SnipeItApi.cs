using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SnipeSharp.Common;
using SnipeSharp.Endpoints;
using SnipeSharp.Endpoints.ExtendedManagers;
using SnipeSharp.Endpoints.Models;

namespace SnipeSharp
{
    public class SnipeItApi
    {
        private static readonly Dictionary<Type, string> TypeUrlMappings = new Dictionary<Type, string>
        {
            {typeof(Asset), "assets"},
            {typeof(Category), "categories"},
            {typeof(Company), "companies"},
            {typeof(Location), "locations"},
            {typeof(Accessory), "accessories"},
            {typeof(Consumable), "consumables"},
            {typeof(Component), "components"},
            {typeof(User), "users"},
            {typeof(StatusLabel), "statuslabels"},
            {typeof(Model), "models"},
            {typeof(License), "licenses"},
            {typeof(Manufacturer), "manufacturers"},
            {typeof(FieldSet), "fieldSets"},
            {typeof(Supplier), "suppliers"},
            {typeof(Depreciation), "deprecations"},
            {typeof(Department), "departments"}
        };
        
        // Test 
        private readonly IRequestManager _reqManager;

        public SnipeItApi()
        {
            this._reqManager = new RequestManagerRestSharp(ApiSettings);
            
            this.AssetManager = new AssetEndpointManager(this._reqManager);
            this.UserManager = new UserEndpointManager(this._reqManager);
            this.StatusLabelManager = new StatusLabelEndpointManager(this._reqManager);
        }

        public ApiSettings ApiSettings { get; } = new ApiSettings();

        public AssetEndpointManager AssetManager { get; }
        
        public IEndpointManager<Company> CompanyManager => this.GetEndpointManager<Company>();
        
        public IEndpointManager<Location> LocationManager => this.GetEndpointManager<Location>();
        
        public IEndpointManager<Accessory> AccessoryManager => this.GetEndpointManager<Accessory>();
        
        public IEndpointManager<Consumable> ConsumableManager => this.GetEndpointManager<Consumable>();
        
        public IEndpointManager<Component> ComponentManager => this.GetEndpointManager<Component>();

        public UserEndpointManager UserManager { get; }

        public StatusLabelEndpointManager StatusLabelManager { get; }
        
        public IEndpointManager<Model> ModelManager => this.GetEndpointManager<Model>();
        
        public IEndpointManager<License> LicenseManager => this.GetEndpointManager<License>();
        
        public IEndpointManager<Category> CategoryManager => this.GetEndpointManager<Category>();
        
        public IEndpointManager<Manufacturer> ManufacturerManager => this.GetEndpointManager<Manufacturer>();
        
        public IEndpointManager<FieldSet> FieldSetManager => this.GetEndpointManager<FieldSet>();

        public IEndpointManager<Supplier> SupplierManager => this.GetEndpointManager<Supplier>();
        
        public IEndpointManager<Depreciation> DepreciationManager => this.GetEndpointManager<Depreciation>();
        
        public IEndpointManager<Department> DepartmentManager => this.GetEndpointManager<Department>();

        public IEndpointManager<T> GetEndpointManager<T>()
            where T : CommonEndpointModel
        {
            var type = typeof(T);

            foreach (var pair in TypeUrlMappings)
            {
                if (type.IsAssignableFrom(pair.Key))
                {
                    return new EndpointManager<T>(this._reqManager, pair.Value);
                }
            }
            
            // FIXME - error message
            throw new NotSupportedException();
        }
    }
}
