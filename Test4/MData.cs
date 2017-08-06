namespace Test4
{
    internal class MData
    {
        private int id;
        private string name;
        private string unit;
        private string stand;
        private string sAllNum;//一箱的数量
        private string sellNum;//卖出的数量
        private string priOne;
        private string allPrice;
        private string allMoney;
        private string note;


        public string Note { get => note; set => note = value; }
        public string AllMoney { get => allMoney; set => allMoney = value; }
        public string AllPrice { get => allPrice; set => allPrice = value; }
        public string PriOne { get => priOne; set => priOne = value; }
        public string SellNum { get => sellNum; set => sellNum = value; }
        public string Stand { get => stand; set => stand = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public string SAllNum { get => sAllNum; set => sAllNum = value; }

        public MData(int id, string name, string unit, string stand,string sAllNum, string sellNum, string priOne, string allPrice, string allMoney, string note)
        {
            this.id = id;
            this.name = name;
            this.unit = unit;
            this.stand = stand;
            this.sAllNum = sAllNum;
            this.sellNum = sellNum;
            this.priOne = priOne;
            this.allPrice = allPrice;
            this.allMoney = allMoney;
            this.note = note;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return base.Equals(obj);
        }

        public bool Equals(MData obj)
        {
            if (obj == null)//步骤1
                return false;
            if (ReferenceEquals(this, obj))//步骤2
                return true;
            //if (this.GetHashCode() != obj.GetHashCode())//步骤5  效率低没有缓存，可以注释
            //    return false;
            System.Diagnostics.Debug.Assert(base.GetType() != typeof(object));
            ////步骤6    基类没有重写可以注释
            //if (!base.Equals(obj))
            //    return false;
            return ((name.Equals(obj.name)) && (unit.Equals(obj.unit)) && (stand.Equals(obj.stand)) && (sellNum.Equals(obj.sellNum)) && (priOne.Equals(obj.priOne)) && (allPrice.Equals(obj.allPrice)) && (allMoney.Equals(obj.allMoney)) && (note.Equals(obj.note)));//步骤7
        }

        /// <summary>
        /// //步骤9
        /// </summary>
        /// <param name="leftHandSide"></param>
        /// <param name="rightHandSide"></param>
        /// <returns></returns>
        public static bool operator ==(MData leftHandSide, MData rightHandSide)
        {
            if (ReferenceEquals(leftHandSide, null))
                return ReferenceEquals(rightHandSide, null);
            return (leftHandSide.Equals(rightHandSide));
        }
        public static bool operator !=(MData leftHandSide, MData rightHandSide)
        {
            return !(leftHandSide == rightHandSide);
        }

        /// <summary>
        /// //步骤8
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return name.GetHashCode() ^ unit.GetHashCode() ^ stand.GetHashCode() ^ sellNum.GetHashCode() ^ priOne.GetHashCode() ^ allPrice.GetHashCode() ^ allMoney.GetHashCode() ^ note.GetHashCode();
        }
    }
}
