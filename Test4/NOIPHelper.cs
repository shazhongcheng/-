using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    class NOIPHelper
    {
        /// <summary>
        ///  组装workbook.
        /// </summary>
        /// <param name="dt">dataTable资源</param>
        /// <param name="columnHeader">表头</param>
        /// <returns></returns>
        public static HSSFWorkbook BuildWorkbook1(DataTable dt, ClientData cd, string columnHeader ,string all)
        {
            var workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet(string.IsNullOrWhiteSpace(dt.TableName) ? "Sheet1" : dt.TableName);

            #region 文件属性信息
            {
                var dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = columnHeader;
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "szc";
                si.ApplicationName = "小型账单管理系统";
                si.LastAuthor = "szc";
                si.Comments = "szc";
                si.Title = "账单";
                si.Subject = "账单";
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            var dateStyle = workbook.CreateCellStyle();
            var format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            var arrColWidth = new int[dt.Columns.Count];
            foreach (DataColumn item in dt.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (var i = 0; i < dt.Rows.Count; i++)
            {
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dt.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dt.Rows)
            {
                #region 表头 列头
                if ((rowIndex == 65535 || rowIndex == 0) && columnHeader != "")
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        var headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(columnHeader);
                        //CellStyle
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                        headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                        // 设置单元格的背景颜色（单元格的样式会覆盖列或行的样式）    
                        headStyle.FillForegroundColor = (short)11;
                        //定义font
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, dt.Columns.Count - 1));
                    }
                    #endregion


                    #region 客户信息
                    {
                        for (int i = 1; i < 1 + 4; i++)
                        {
                            var headerRow = sheet.CreateRow(i);
                            switch (i)
                            {
                                case 1:
                                    headerRow.CreateCell(0).SetCellValue("收货单位:");
                                    headerRow.CreateCell(1).SetCellValue(cd.Name);
                                    break;
                                case 2:
                                    headerRow.CreateCell(0).SetCellValue("电话:");
                                    headerRow.CreateCell(1).SetCellValue(cd.Tel);
                                    break;
                                case 3:
                                    headerRow.CreateCell(0).SetCellValue("地址:");
                                    headerRow.CreateCell(1).SetCellValue(cd.Add);
                                    break;
                                case 4:
                                    headerRow.CreateCell(0).SetCellValue("日期:");
                                    headerRow.CreateCell(1).SetCellValue(cd.Data);
                                    break;
                                default:
                                    break;
                            }
                            //CellStyle
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                            headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                                                                                   //定义font
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell(0).CellStyle = headStyle;
                            headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                            headerRow.GetCell(1).CellStyle = headStyle;
                            //合并

                            sheet.AddMergedRegion(new CellRangeAddress(i, i, 1, dt.Columns.Count - 1));
                        }
                    }
                    #endregion

                    #region 列头及样式
                    {
                        var headerRow = sheet.CreateRow(5);
                        //CellStyle
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                        headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                        //定义font
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        foreach (DataColumn column in dt.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                    }
                    #endregion
                    
                    ///**
                    // *
                    // *如果标题为空
                    // */
                    //if ((rowIndex == 65535 || rowIndex == 0) && columnHeader == "")
                    //{
                    //    //header row
                    //    IRow row0 = sheet.CreateRow(0);
                    //    for (int i = 0; i < dt.Columns.Count; i++)
                    //    {
                    //        ICell cell = row0.CreateCell(i, CellType.String);
                    //        cell.SetCellValue(dt.Columns[i].ColumnName);
                    //    }
                    //}  

                    rowIndex = 6;
                }
                #endregion


                #region 内容
                var dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dt.Columns)
                {
                    var newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            if(column.Ordinal==7 || column.Ordinal == 6|| column.Ordinal == 5)
                            {
                                newCell.SetCellValue(Convert.ToDouble(new StringBuilder(drValue).Remove(drValue.Length - 1, 1).ToString()));

                                ICellStyle _intCellStyle = null;
                                _intCellStyle = workbook.CreateCellStyle();
                                _intCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("¥#,##0.00");
                                //newCell.SetCellType(CellType.Numeric);
                                newCell.CellStyle = _intCellStyle;

                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                            } 
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            //自动列宽
            for (int i = 0; i <= dt.Columns.Count; i++)
                sheet.AutoSizeColumn(i, true);

            //合计
            {
                var dataRow = sheet.CreateRow(rowIndex);
                {
                    var newCell = dataRow.CreateCell(0);
                    newCell.SetCellValue("合计：");
                }
                {
                    var newCell = dataRow.CreateCell(1);
                    newCell.SetCellValue(Convert.ToDouble(new StringBuilder(all).Remove(all.Length - 1, 1).ToString()));
                    /*设置货币格式货币*/
                    //newCell.SetCellType(CellType.Numeric);
                    ICellStyle _intCellStyle = null;
                    _intCellStyle = workbook.CreateCellStyle();
                    //CellStyle
                    _intCellStyle.Alignment = HorizontalAlignment.Right;// 左右居中    
                    _intCellStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                    _intCellStyle.DataFormat = workbook.CreateDataFormat().GetFormat("¥#,##0.00");
                    //定义font
                    IFont font = workbook.CreateFont();
                    font.FontHeightInPoints = 10;
                    font.Boldweight = 700;
                    _intCellStyle.SetFont(font);
                    newCell.CellStyle = _intCellStyle;             
                    //合并

                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 1, dt.Columns.Count - 1));
                }
                rowIndex++;
            }

            //表尾
            for (int i= 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        var headerRow = sheet.CreateRow(rowIndex);
                        for (int j = 1; j < 4; j++)
                        { 
                            switch (j)
                            {
                                case 1:
                                    headerRow.CreateCell(0).SetCellValue("厂址：兴化市林湖工业园区");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 2));
                                    break;
                                case 2:
                                    headerRow.CreateCell(3).SetCellValue("电话：0523-83877988");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 3, 5));
                                    break;
                                case 3:
                                    headerRow.CreateCell(6).SetCellValue("传真：0523-83877228");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 6, 8));
                                    break;
                                default:
                                    break;
                            }
                            //CellStyle
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                            headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                                                                                   //定义font
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell((j - 1) * 3).CellStyle = headStyle;
                            
                        }
                        break;
                    case 1:
                        headerRow = sheet.CreateRow(rowIndex);
                        for (int j = 1; j < 3; j++)
                        {  
                            switch (j)
                            {
                                case 1:
                                    headerRow.CreateCell((j - 1) * 4).SetCellValue("网址:http://www.foodbinwang.com");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 4));
                                    break;
                                case 2:
                                    headerRow.CreateCell((j - 1) * 4).SetCellValue("网址:http://bwtwsp.cn.alibaba.com");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 5, 8));
                                    break;
                                default:
                                    break;
                            }
                            //CellStyle
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                            headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                                                                                   //定义font
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell((j - 1) * 4).CellStyle = headStyle;
                        }
                        break;
                    case 2:
                        headerRow = sheet.CreateRow(rowIndex);
                        for (int j = 1; j < 3; j++)
                        {  
                            switch (j)
                            {
                                case 1:
                                    headerRow.CreateCell((j - 1) * 4).SetCellValue("邮箱:624450148@qq.com");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 0, 4));
                                    break;
                                case 2:
                                    headerRow.CreateCell((j - 1) * 4).SetCellValue("手机:13805269881");
                                    sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, 5, 8));
                                    break;
                                default:
                                    break;
                            }
                            //CellStyle
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;// 左右居中    
                            headStyle.VerticalAlignment = VerticalAlignment.Center;// 上下居中 
                                                                                   //定义font
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            headerRow.GetCell((j - 1) * 4).CellStyle = headStyle;
                            //合并

                            sheet.AddMergedRegion(new CellRangeAddress(rowIndex, rowIndex, (j - 1) * 4, (j) * 4-1));
                        }
                        break;
                    default:
                        break;
                }
                rowIndex++;
            }

            return workbook;
        }

    }
}
