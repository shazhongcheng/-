using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test4
{
    class ClientData
    {
        private string name;
        private string tel;
        private string add;
        private string data;

        public ClientData(string name, string tel, string add, string data)
        {
            this.name = name;
            this.tel = tel;
            this.add = add;
            this.data = data;
        }

        public string Name { get => name; set => name = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Add { get => add; set => add = value; }
        public string Data { get => data; set => data = value; }
    }
}
