using System;
using RomanCalculatorFramework;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RomanCalculatorFramework.Entity;
using RomanCalculatorFramework.Interface;

namespace RomanCalculatorBusinessComponent.RomanNumberToInteger
{
    public class ConvertRomanNumberToInger
    {
        INumberDataSet numberDataset;
        List<string> RoamnMinCategoriesEnums = new List<string>()
        {
            "V",
            "L",
            "D"
        };

        public ConvertRomanNumberToInger(INumberDataSet dataset)
        {
            numberDataset = dataset;
        }

        public int ConvertRomantoInt(string romanValue)
        {
            string pattern = @"[XCM]";

            int result = 0;

            if (Regex.IsMatch(romanValue, pattern))
            {
                foreach (var item in Enum.GetNames(typeof(RoamnNumberCategoriesEnums)))
                {
                    var index = romanValue.IndexOf(item);

                    var entity = new RomanNumberEntity();

                    if (index > -1)
                    {
                        entity.RoamnNumberValue = romanValue.Substring(index);

                        entity.RomanNumberInt = GetIntValue(entity.RoamnNumberValue);

                        romanValue = romanValue.Replace(entity.RoamnNumberValue, "");
                    }

                    result += entity.RomanNumberInt;
                }
            }
            else
            {
                result = GetIntValue(romanValue);
            }
           

            return result;
        }

        private int GetIntValue(string value)
        {
            int result = 0;
            var charArray = value.ToCharArray();

            for (int i=0; i< charArray.Length; i++)
            {
                if(i==1)
                {
                    if (RoamnMinCategoriesEnums.Contains(charArray[(i)].ToString()) && (i - 1 > -1))
                    {
                        var current = numberDataset.GetIntegerVaue(charArray[i].ToString());

                        var previous = numberDataset.GetIntegerVaue(charArray[i - 1].ToString());

                        result = current - previous;
                    }
                    else
                    {
                        result += numberDataset.GetIntegerVaue(charArray[i].ToString());
                    }
                }
                else
                    result += numberDataset.GetIntegerVaue(charArray[i].ToString());
            }

            return result;
        }
    }
}
