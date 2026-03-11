using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DalList;

namespace Dal;

    internal sealed class DalList:IDal
    {
    private DalList() {
    }
    private readonly DalList instance =new DalList();
    public int MyProperty { get; set; }
    public readonly static DalList Instance = { get  instance };
        public ISale Sale => new SaleImplementation();
        public IProduct Product => new ProductImplementation();
        public ICustomer Customer => new CustomerImplementation();

    }

