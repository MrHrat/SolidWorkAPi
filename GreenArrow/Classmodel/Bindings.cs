using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GreenArrow
{
    [Serializable]
    public class Bindings
    {
        public BindingList<String[]> pack;
        
        public Bindings()
        {
            pack = new BindingList<String[]>();
        }

        public void AddBindings(string name, string[] listcount)
        {
            List<string> parts = new List<string>();
            parts.Add(name);
            parts.AddRange(listcount);

            pack.Add(parts.ToArray());
        }

        public void makeBindings(ModelDoc2 swModel)
        {            
            foreach (string[] list in pack)
            {
                swModel.ClearSelection2(true);

                for (int i = 1; i < list.Length; i++)
                    SmartTools.SelectByID(swModel, list[i]);

                swModel.SketchAddConstraints(list[0]);
            }
        }
    }

    [Serializable]
    public class Dimensions
    {
        public BindingList<String[]> pack;

        public Dimensions()
        {
            pack = new BindingList<String[]>();
        }

        //AddDimensions("L1", "P1", 17.5, 0.0, 0.0, 0.0, ["1", "2"]);
        public void AddDimensions(string name, string parameter, double defaultvalue, double Xkor, double Ykor, double Zkor, string[] listcount)
        {
            List<string> parts = new List<string>();
            parts.Add(name);                            //Назва розміру
            parts.Add(parameter);                       //назва за яким виділяється розмір
            parts.Add(defaultvalue.ToString());         //Зазамовчуванням - використовується для збірки
            parts.Add(Xkor.ToString());                 //координати х у z
            parts.Add(Ykor.ToString());                 //
            parts.Add(Zkor.ToString());                 //
            parts.AddRange(listcount);                  //ціле число номер кривої в списку
            
            pack.Add(parts.ToArray());            
        }

        public void makeDimensions(ModelDoc2 swModel)
        {            
            foreach (string[] list in pack)
            {
                swModel.ClearSelection2(true);

                for (int i = 6; i < list.Length; i++)
                    SmartTools.SelectByID(swModel, list[i]);

                swModel.AddDimension2(Convert.ToDouble(list[3]), Convert.ToDouble(list[4]), Convert.ToDouble(list[5]));
            }
        }

        public void changeDimensions(ModelDoc2 swModel)
        {
            Dimension myDimension;

            foreach (string[] list in pack)
            {
                if (list[0] != "")
                {
                    myDimension = swModel.Parameter(list[1]);
                    myDimension.SystemValue = Convert.ToDouble(list[2]) / 1000.0;
                }                
            }

            SmartTools.UpdateModel(swModel);
        }

        public String[] getName()
        { 
            List<String> list = new List<String>();
            foreach(String[] mas in pack)
            {
                if (!((mas[0] == null) || (mas[0] == "")))
                    list.Add(mas[0]);
            }
            return list.ToArray();
        }

        public double getcount(string name)
        {
            foreach (string[] list in pack)
            {
                if (list[0] == name)
                    return Convert.ToDouble(list[2]);
            }
            return 0.0;
        }

        public void setcount(string name, double value)
        {
            BindingList<String[]> packdelet = new BindingList<String[]>();

            foreach (string[] list in pack)
            {
                if (list[0] == name)
                {
                    packdelet.Add(list);
                }
            }

            foreach (string[] list in packdelet)
            {
                pack.Remove(list);
                list[2] = value.ToString("N");
                pack.Add(list);
            }
        }
    }

    [Serializable]
    public class Validation
    {
        public BindingList<Inequality> pack;

        public Validation()
        {
            pack = new BindingList<Inequality>();
        }       

        public void AddInequality(Inequality value)
        {
            pack.Add(value);
        }

        public bool isTrue(Dimensions dim, out String Message)
        {
            foreach (Inequality obj in pack)
            {
                if (!obj.isTrue(dim, out Message))
                {
                    return false;
                }
            }
            
            Message = "Всі розміри вірні!";
            return true;
        }
    }

    [Serializable]
    public class Inequality
    {
        public BindingList<String[]> Ineq;

        public Inequality()
        {
            Ineq = new BindingList<String[]>();
        }

        /*
        Ineq [[A1 *  2] +
              [B1 * -1] +
              [L]];
        
        2*A1 < -B1 + L
        */
        public Inequality(String[][] xesh)
        {
            Ineq = new BindingList<String[]>();

            for (int i = 0; i < xesh.Length; i++)
            {
                Ineq.Add(xesh[i]);
            }
        }

        public void AddAmountOfParts(String[] array)
        {
            Ineq.Add(array);
        }

        public bool isTrue(Dimensions dim, out String Message)
        {
            Double[] mas = new Double[Ineq.Count];
            String[] Str = new String[Ineq.Count];

            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 1.0;                
            }

            for (int j = 0; j < Ineq.Count; j++)
            {
                Str[j] = "";
            }

            double number;
            int k = 0;

            foreach(String[] Col in Ineq)
            {
                for (int i = 0; i < Col.Length; i++)
                {
                    if (Double.TryParse(Col[i], out number))
                    {
                        mas[k] *= number;
                    }
                    else
                    {
                        mas[k] *= dim.getcount(Col[i]);
                    }
                    if ((Str[k] != "")) Str[k] += " * ";
                    Str[k] += Col[i];
                }
                k++;
            }

            mas[0] *= -1.0;
            if (0 < mas.Sum())
            {
                Message = "Розміри вірні!";
                return true;
            }
            else
            {
                Message = "Розміри невірні!\nПомилка нерівності:\n";
                Message += Str[0] + " < " + Str[1];
                for (int i = 2; i < Str.Length; i++)
                {
                    Message += " + " + Str[i];
                }
                mas[0] *= -1.0;
                double rsuma = mas.Sum() - mas[0];
                Message += "\n" + mas[0].ToString("N") + " < " + rsuma.ToString("N");                
                return false;
            }
        }
    }
}
