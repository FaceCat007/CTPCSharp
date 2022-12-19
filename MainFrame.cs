/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FaceCat;
using System.Net;
using System.IO;

namespace ctpstrategy
{
    /// <summary>
    /// 主窗体框架
    /// </summary>
    public class MainFrame : UIXmlEx, FCTouchEventCallBack, FCGridCellTouchEventCallBack
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MainFrame()
        {
        }

        public String m_currentCode = "";

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender">调用者</param>
        /// <param name="mp">坐标</param>
        /// <param name="button">按钮</param>
        /// <param name="clicks">点击次数</param>
        /// <param name="delta">滚轮值/param>
        public void callTouchEvent(string eventName, object sender, FCTouchInfo touchInfo, object invoke)
        {
            if (touchInfo.m_firstTouch && touchInfo.m_clicks == 1)
            {
                FCView control = sender as FCView;
                String name = control.getName();
                if (name == "cbInvestorPosition")
                {
                    FCGrid gridInvestorPosition = getGrid("gridInvestorPosition");
                    FCGrid gridInvestorPositionDetail = getGrid("gridInvestorPositionDetail");
                    gridInvestorPosition.m_visible = true;
                    gridInvestorPositionDetail.m_visible = false;
                    gridInvestorPosition.update();
                    gridInvestorPosition.invalidate();
                }
                else if (name == "cbInvestorPositionDetail")
                {
                    FCGrid gridInvestorPosition = getGrid("gridInvestorPosition");
                    FCGrid gridInvestorPositionDetail = getGrid("gridInvestorPositionDetail");
                    gridInvestorPosition.m_visible = false;
                    gridInvestorPositionDetail.m_visible = true;
                    gridInvestorPositionDetail.update();
                    gridInvestorPositionDetail.invalidate();
                }
                else if (name == "btnOrder")
                {
                    FCView txtIssueCode = findView("txtIssueCode");
                    FCView spinVolume = findView("spinVolume");
                    FCView spinPrice = findView("spinPrice");
                    FCRadioButton rbBuy = getRadioButton("rbBuy");
                    FCRadioButton rbSell = getRadioButton("rbSell");
                    FCRadioButton rbOpen = getRadioButton("rbOpen");
                    FCRadioButton rbCloseToday = getRadioButton("rbCloseToday");
                    FCRadioButton rbClose = getRadioButton("rbClose");
                    String issueCode = txtIssueCode.getText();
                    if (m_allCodes.containsKey(issueCode))
                    {
                        String exchangeID = m_allCodes[issueCode].exchangeID;
                        int volume = FCTran.strToInt(spinVolume.getText());
                        double price = FCTran.strToDouble(spinPrice.getText());
                        String bCode = issueCode;
                        String bExchangeID = exchangeID;
                        double bPrice = price;
                        int bVolume = volume;
                        char bCondition = '3';
                        if (rbBuy.isChecked())
                        {
                            if (rbOpen.isChecked())
                            {
                                CTPDLL.bidOpen(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                            else if (rbCloseToday.isChecked())
                            {
                                CTPDLL.bidCloseToday(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                            else if (rbClose.isChecked())
                            {
                                CTPDLL.bidClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                        }
                        else
                        {
                            if (rbOpen.isChecked())
                            {
                                CTPDLL.askOpen(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                            else if (rbCloseToday.isChecked())
                            {
                                CTPDLL.askCloseToday(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                            else if (rbClose.isChecked())
                            {
                                CTPDLL.askClose(m_ctpID, CTPDLL.generateReqID(m_ctpID), bCode, bExchangeID, bPrice, bVolume, bCondition, "");
                            }
                        }
                    }
                }
                else if (name == "btnCancelOrder2")
                {
                    FCGrid gridOrder = getGrid("gridOrder");
                    ArrayList<FCGridRow> selectedRows = gridOrder.getSelectedRows();
                    if (selectedRows.size() > 0)
                    {
                        String orderSysID = selectedRows.get(0).getCell(0).getString();
                        String exchangeID = selectedRows.get(0).getCell(16).getString();
                        CTPDLL.cancelOrder(m_ctpID, CTPDLL.generateReqID(m_ctpID), exchangeID, orderSysID, "");
                    }
                }
            }
        }


        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="control">控件</param>
        public override void loadFile(string fileName, FCView control)
        {
            base.loadFile(fileName, control);
            loginCTP("simnow_client_test", "0000000000000000", "180.168.146.187:10212", "180.168.146.187:10202", "9999", "021739", "123456");
            findView("cbInvestorPosition").addEvent(this, FCEventID.Click, this);
            findView("cbInvestorPositionDetail").addEvent(this, FCEventID.Click, this);
            findView("btnOrder").addEvent(this, FCEventID.Click, this);
            findView("btnCancelOrder2").addEvent(this, FCEventID.Click, this);

            getGrid("gridLatestData").addEvent(this, FCEventID.GridCellClick, this);
            getGrid("gridInvestorPosition").addEvent(this, FCEventID.GridCellClick, this);
            getGrid("gridInvestorPositionDetail").addEvent(this, FCEventID.GridCellClick, this);

            FCChart chart = getChart("chart");
            chart.setRightVScaleWidth(80);
            chart.setLeftVScaleWidth(0);
            
            ChartDiv candleDiv = chart.addDiv(60);
            candleDiv.getHScale().setHeight(0);
            candleDiv.getHScale().setVisible(false);
            candleDiv.setBackColor(FCColor.Back);
            ChartDiv volDiv = chart.addDiv(40);
            volDiv.getHScale().setHeight(20);
            volDiv.getHScale().setVisible(true);
            volDiv.setBackColor(FCColor.Back);
            candleDiv.getTitleBar().m_titles.add(new ChartTitle(0, "CLOSE", FCColor.rgb(255, 255, 255), 0, true));
            volDiv.getTitleBar().m_titles.add(new ChartTitle(1, "VOL", FCColor.rgb(255, 255, 255), 0, true));

            FCDataTable dataSource = chart.getDataSource();
            dataSource.addColumn(0);
            dataSource.addColumn(1);
            
            PolylineShape ps = new PolylineShape();
            ps.setFieldName(0);
            ps.setFieldText("CLOSE");
            candleDiv.addShape(ps);

            BarShape bs = new BarShape();
            bs.setFieldName(1);
            bs.setFieldText("VOL");
            volDiv.addShape(bs);
        }

        /// <summary>
        /// 资金账户信息回调
        /// </summary>
        /// <param name="data">资金账户</param>
        public virtual void onAccountDataCallBack(AccountData data, int ctpID)
        {
            FCGrid gridTradeAccount = getGrid("gridTradeAccount");
            gridTradeAccount.m_headerHeight = 30;
            gridTradeAccount.m_showHScrollBar = true;
            gridTradeAccount.getRowStyle().setSelectedBackColor(FCColor.None);
            gridTradeAccount.setGridLineColor(FCColor.None);
            for (int i = 0; i < gridTradeAccount.m_columns.size(); i++)
            {
                gridTradeAccount.m_columns[i].m_allowSort = false;
                gridTradeAccount.m_columns[i].setWidth(140);
            }
            FCGridRow row = null;
            if (gridTradeAccount.m_rows.size() == 0)
            {
                row = new FCGridRow();
                row.setHeight(30);
                gridTradeAccount.addRow(row);
                for (int i = 0; i < gridTradeAccount.m_columns.size(); i++)
                {
                    FCGridStringCell cell1 = new FCGridStringCell();
                    row.addCell(i, cell1);
                }
            }
            gridTradeAccount.m_rows[0].m_cells[0].setString(FCTran.getValueByDigit(data.balance, 0));
            gridTradeAccount.m_rows[0].m_cells[1].setString(FCTran.getValueByDigit(data.closeProfit, 0));
            gridTradeAccount.m_rows[0].m_cells[2].setString(FCTran.getValueByDigit(data.floatProfit, 0));
            gridTradeAccount.m_rows[0].m_cells[3].setString(FCTran.getValueByDigit(data.positionProfit, 0));
            gridTradeAccount.m_rows[0].m_cells[4].setString(FCTran.getValueByDigit(data.dynamicBalance, 0));
            gridTradeAccount.m_rows[0].m_cells[5].setString(FCTran.getValueByDigit(data.currMargin, 0));
            gridTradeAccount.m_rows[0].m_cells[6].setString(FCTran.getValueByDigit(data.frozenCash, 0));
            gridTradeAccount.m_rows[0].m_cells[7].setString(FCTran.getValueByDigit(data.available, 0));
            gridTradeAccount.m_rows[0].m_cells[8].setString(FCTran.getValueByDigit(data.risk * 100, 2) + "%");
            gridTradeAccount.m_rows[0].m_cells[9].setString(FCTran.getValueByDigit(data.frozenMargin, 0));
            gridTradeAccount.m_rows[0].m_cells[10].setString(FCTran.getValueByDigit(data.frozenCommission, 0));
            gridTradeAccount.m_rows[0].m_cells[11].setString(FCTran.getValueByDigit(data.commission, 0));
            gridTradeAccount.m_rows[0].m_cells[12].setString(FCTran.getValueByDigit(data.preBalance, 0));
            gridTradeAccount.m_rows[0].m_cells[13].setString(FCTran.getValueByDigit(data.preCredit, 0));
            gridTradeAccount.m_rows[0].m_cells[14].setString(FCTran.getValueByDigit(data.preMortgage, 0));
            gridTradeAccount.m_rows[0].m_cells[15].setString(FCTran.getValueByDigit(data.mortgage, 0));
            gridTradeAccount.m_rows[0].m_cells[16].setString(FCTran.getValueByDigit(data.withdraw, 0));
            gridTradeAccount.m_rows[0].m_cells[17].setString(FCTran.getValueByDigit(data.deposit, 0));
            gridTradeAccount.m_rows[0].m_cells[18].setString(FCTran.getValueByDigit(data.credit, 0));
            gridTradeAccount.m_rows[0].m_cells[19].setString(FCTran.getValueByDigit(data.reserveBalance, 0));
            gridTradeAccount.m_rows[0].m_cells[20].setString(FCTran.getValueByDigit(data.withdrawQuota, 0));
            gridTradeAccount.update();
            gridTradeAccount.invalidate();
        }

        /// <summary>
        /// 持仓数据回调
        /// </summary>
        /// <param name="data">持仓</param>
        public virtual void onInvestorPositionCallBack(List<InvestorPosition> data, int ctpID)
        {
            FCGrid gridInvestorPosition = getGrid("gridInvestorPosition");
            gridInvestorPosition.setGridLineColor(FCColor.None);
            for (int i = 0; i < data.Count; i++)
            {
                FCGridRow row = null;
                for (int j = 0; j < gridInvestorPosition.m_rows.size(); j++)
                {
                    if (gridInvestorPosition.m_rows[j].m_cells[0].getString() + gridInvestorPosition.m_rows[j].m_cells[1].getString() == data[i].code + data[i].posiDirection)
                    {
                        row = gridInvestorPosition.m_rows[j];
                        break;
                    }
                }
                if (row == null)
                {
                    row = new FCGridRow();
                    row.setHeight(30);
                    gridInvestorPosition.addRow(row);
                    for (int j = 0; j < gridInvestorPosition.m_columns.size(); j++)
                    {
                        FCGridStringCell cell1 = new FCGridStringCell();
                        row.addCell(j, cell1);
                    }
                }
                row.m_cells[0].setString(data[i].code);
                row.m_cells[1].setString(data[i].posiDirection);
                row.m_cells[2].setString(FCTran.intToStr(data[i].ydPosition + data[i].todayPosition));
                row.m_cells[3].setString(FCTran.intToStr(data[i].ydPosition));
                row.m_cells[4].setString(FCTran.intToStr(data[i].todayPosition));
                row.m_cells[5].setString("0");
                row.m_cells[6].setString(FCTran.getValueByDigit(data[i].positionCost, 0));
                row.m_cells[7].setString(FCTran.getValueByDigit(data[i].positionProfit, 0));
                row.m_cells[8].setString(FCTran.getValueByDigit(data[i].margin, 0));
                row.m_cells[9].setString(data[i].hedgeFlag);
                row.m_cells[10].setString(data[i].code);
                row.m_cells[11].setString("0");
                row.m_cells[12].setString("0");
                row.m_cells[13].setString("0");
                row.m_cells[14].setString("0");
                row.m_cells[15].setString("0");
                row.m_cells[16].setString("0");
                row.m_cells[17].setString("0");
                row.m_cells[18].setString("0");
                row.m_cells[19].setString("0");
                row.m_cells[20].setString("0");
                row.m_cells[21].setString("0");
                row.m_cells[22].setString("0");
                row.m_cells[23].setString("0");
                row.m_cells[24].setString("0");
                row.m_cells[25].setString("0");
                row.m_cells[26].setString("0");
                row.m_cells[27].setString("0");
                row.m_cells[28].setString("0");
                row.m_cells[29].setString("0");
                row.m_cells[30].setString("0");
            }
            int rowsSize = gridInvestorPosition.m_rows.size();
            for (int i = 0; i < rowsSize; i++)
            {
                FCGridRow row = gridInvestorPosition.m_rows.get(i);
                if (row.getCell(2).getString() == "0")
                {
                    gridInvestorPosition.removeRow(row);
                    row.delete();
                    i--;
                    rowsSize--;
                }
            }
            gridInvestorPosition.update();
            gridInvestorPosition.invalidate();
        }

        /// <summary>
        /// 持仓数据回调
        /// </summary>
        /// <param name="data">持仓明细</param>
        public virtual void onInvestorPositionDetailCallBack(List<InvestorPositionDetail> data, int ctpID)
        {
            FCGrid gridInvestorPositionDetail = getGrid("gridInvestorPositionDetail");
            gridInvestorPositionDetail.setGridLineColor(FCColor.None);
            for (int i = 0; i < data.Count; i++)
            {
                FCGridRow row = null;
                for (int j = 0; j < gridInvestorPositionDetail.m_rows.size(); j++)
                {
                    if (gridInvestorPositionDetail.m_rows[j].m_cells[0].getString() == data[i].tradeID)
                    {
                        row = gridInvestorPositionDetail.m_rows[j];
                        break;
                    }
                }
                if (row == null)
                {
                    row = new FCGridRow();
                    row.setHeight(30);
                    gridInvestorPositionDetail.addRow(row);
                    for (int j = 0; j < gridInvestorPositionDetail.m_columns.size(); j++)
                    {
                        FCGridStringCell cell1 = new FCGridStringCell();
                        row.addCell(j, cell1);
                    }
                }
                row.m_cells[0].setString(data[i].tradeID);
                row.m_cells[1].setString(data[i].code);
                row.m_cells[2].setString(data[i].direction);
                row.m_cells[3].setString(FCTran.getValueByDigit(data[i].volume, 0));
                row.m_cells[4].setString(FCTran.getValueByDigit(data[i].openPrice, 0));
                row.m_cells[5].setString(FCTran.getValueByDigit(data[i].margin, 0));
                row.m_cells[6].setString(data[i].tradeType);
                row.m_cells[7].setString(data[i].hedgeFlag);
                row.m_cells[8].setString(data[i].openDate);
                row.m_cells[9].setString(FCTran.getValueByDigit(data[i].positionProfit, 0));
                row.m_cells[10].setString(FCTran.getValueByDigit(data[i].closeProfitByTrade, 0));
                row.m_cells[11].setString(data[i].exchangeID);
                row.m_cells[12].setString("普通持仓");
                row.m_cells[13].setString(FCTran.getValueByDigit(data[i].preSettlementPrice, 0));
                row.m_cells[14].setString(FCTran.getValueByDigit(data[i].closeVolume, 0));
                row.m_cells[15].setString(FCTran.getValueByDigit(data[i].floatProfit, 0));
                row.m_cells[16].setString(FCTran.getValueByDigit(data[i].openPrice, 0));
                row.m_cells[17].setString(data[i].combInstrumentID);
            }
            int rowsSize = gridInvestorPositionDetail.m_rows.size();
            for (int i = 0; i < rowsSize; i++)
            {
                FCGridRow row = gridInvestorPositionDetail.m_rows.get(i);
                if (row.getCell(3).getString() == "0")
                {
                    gridInvestorPositionDetail.removeRow(row);
                    row.delete();
                    i--;
                    rowsSize--;
                }
            }
            gridInvestorPositionDetail.update();
            gridInvestorPositionDetail.invalidate();
        }


        /// <summary>
        /// 推送的委托回报回调
        /// </summary>
        /// <param name="data">委托回报</param>
        public virtual void onOrderInfoCallBack(OrderInfo data, int ctpID)
        {
            if (data.orderStatus == "未知")
            {
                return;
            }
            FCGrid gridOrder = getGrid("gridOrder");
            gridOrder.setGridLineColor(FCColor.None);
            FCGridRow row = null;
            for (int i = 0; i < gridOrder.m_rows.size(); i++)
            {
                if (gridOrder.m_rows[i].m_cells[0].getString() == data.orderSysID)
                {
                    row = gridOrder.m_rows[i];
                    break;
                }
            }
            if (row == null)
            {
                row = new FCGridRow();
                row.setHeight(30);
                gridOrder.insertRow(0, row);
                for (int j = 0; j < gridOrder.m_columns.size(); j++)
                {
                    FCGridStringCell cell1 = new FCGridStringCell();
                    row.addCell(j, cell1);
                }
            }
            row.m_cells[0].setString(data.orderSysID);
            row.m_cells[1].setString(data.code);
            row.m_cells[2].setString(data.direction);
            row.m_cells[3].setString(data.combOffsetFlag);
            row.m_cells[4].setString(data.orderStatus);
            row.m_cells[5].setString(FCTran.getValueByDigit(data.limitPrice, 0));
            row.m_cells[6].setString(data.volumeTotalOriginal.ToString());
            row.m_cells[7].setString(data.volumeTotal.ToString());
            row.m_cells[8].setString(data.volumeTotal.ToString());
            row.m_cells[9].setString(data.volumeTraded.ToString());
            row.m_cells[10].setString(data.insertTime);
            row.m_cells[11].setString(data.updateTime);
            row.m_cells[12].setString(FCTran.getValueByDigit(data.limitPrice, 0));
            row.m_cells[13].setString("0");
            row.m_cells[14].setString("0");
            row.m_cells[15].setString(data.combHedgeFlag);
            row.m_cells[16].setString(data.exchangeID);
            row.m_cells[17].setString(data.orderPriceType);
            row.m_cells[18].setString(data.timeCondition);
            row.m_cells[19].setString(data.orderType);
            row.m_cells[20].setString(data.userForceClose.ToString());
            row.m_cells[21].setString(data.forceCloseReason);
            row.m_cells[22].setString("");
            row.m_cells[23].setString("");
            gridOrder.update();
            gridOrder.invalidate();
        }

        /// <summary>
        /// 主动查询的委托回报回调
        /// </summary>
        /// <param name="data">委托回报列表</param>
        public virtual void onOrderInfosCallBack(List<OrderInfo> data, int ctpID)
        {
            FCGrid gridOrder = getGrid("gridOrder");
            gridOrder.setGridLineColor(FCColor.None);
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].orderStatus == "未知")
                {
                    return;
                }
                FCGridRow row = null;
                for (int j = 0; j < gridOrder.m_rows.size(); j++)
                {
                    if (gridOrder.m_rows[j].m_cells[0].getString() == data[i].orderSysID)
                    {
                        row = gridOrder.m_rows[j];
                        break;
                    }
                }
                if (row == null)
                {
                    row = new FCGridRow();
                    row.setHeight(30);
                    gridOrder.insertRow(0, row);
                    for (int j = 0; j < gridOrder.m_columns.size(); j++)
                    {
                        FCGridStringCell cell1 = new FCGridStringCell();
                        row.addCell(j, cell1);
                    }
                }
                row.m_cells[0].setString(data[i].orderSysID);
                row.m_cells[1].setString(data[i].code);
                row.m_cells[2].setString(data[i].direction);
                row.m_cells[3].setString(data[i].combOffsetFlag);
                row.m_cells[4].setString(data[i].orderStatus);
                row.m_cells[5].setString(FCTran.getValueByDigit(data[i].limitPrice, 0));
                row.m_cells[6].setString(data[i].volumeTotalOriginal.ToString());
                row.m_cells[7].setString(data[i].volumeTotal.ToString());
                row.m_cells[8].setString(data[i].volumeTotal.ToString());
                row.m_cells[9].setString(data[i].volumeTraded.ToString());
                row.m_cells[10].setString(data[i].insertTime);
                row.m_cells[11].setString(data[i].updateTime);
                row.m_cells[12].setString(FCTran.getValueByDigit(data[i].limitPrice, 0));
                row.m_cells[13].setString("0");
                row.m_cells[14].setString("0");
                row.m_cells[15].setString(data[i].combHedgeFlag);
                row.m_cells[16].setString(data[i].exchangeID);
                row.m_cells[17].setString(data[i].orderPriceType);
                row.m_cells[18].setString(data[i].timeCondition);
                row.m_cells[19].setString(data[i].orderType);
                row.m_cells[20].setString(data[i].userForceClose.ToString());
                row.m_cells[21].setString(data[i].forceCloseReason);
                row.m_cells[22].setString("");
                row.m_cells[23].setString("");
            }
            gridOrder.update();
            gridOrder.invalidate();
        }

        public HashMap<String, Security> m_allCodes = new HashMap<string, Security>();
        public HashMap<String, SecurityLatestData> m_allDatas = new HashMap<string, SecurityLatestData>();

        /// <summary>
        /// 码表回调
        /// </summary>
        /// <param name="data">码表</param>
        public virtual void onSecurityCallBack(List<Security> data, int ctpID)
        {
            FCGrid contractGrid = getGrid("gridContracts");
            contractGrid.setGridLineColor(FCColor.None);
            for (int i = 0; i < data.Count; i++)
            {
                m_allCodes.put(data[i].instrumentID, data[i]);
                FCGridRow row = new FCGridRow();
                row.setHeight(30);
                contractGrid.addRow(row);
                FCGridStringCell cell1 = new FCGridStringCell();
                cell1.setString(data[i].productID);
                row.addCell(0, cell1);
                FCGridStringCell cell2 = new FCGridStringCell();
                cell2.setString(data[i].instrumentID);
                row.addCell(0, cell2);
                FCGridStringCell cell3 = new FCGridStringCell();
                cell3.setString(data[i].instrumentName);
                row.addCell(0, cell3);
                FCGridStringCell cell4 = new FCGridStringCell();
                cell4.setString(data[i].exchangeID);
                row.addCell(0, cell4);
                FCGridStringCell cell5 = new FCGridStringCell();
                cell5.setString(data[i].volumeMultiple.ToString());
                row.addCell(0, cell5);
                FCGridStringCell cell6 = new FCGridStringCell();
                cell6.setString(data[i].priceTick.ToString());
                row.addCell(0, cell6);
                FCGridStringCell cell7 = new FCGridStringCell();
                cell7.setString("期货");
                row.addCell(0, cell7);
                FCGridStringCell cell8 = new FCGridStringCell();
                cell8.setString(data[i].expireDate);
                row.addCell(0, cell8);
                FCGridStringCell cell9 = new FCGridStringCell();
                cell9.setString(data[i].longMarginRatio.ToString());
                row.addCell(0, cell9);
                FCGridStringCell cell10 = new FCGridStringCell();
                cell10.setString(data[i].shortMarginRatio.ToString());
                row.addCell(0, cell10);
                FCGridStringCell cell11 = new FCGridStringCell();
                cell11.setString("0");
                row.addCell(0, cell11);
                FCGridStringCell cell12 = new FCGridStringCell();
                cell12.setString("0");
                row.addCell(0, cell12);
                FCGridStringCell cell13 = new FCGridStringCell();
                cell13.setString("0");
                row.addCell(0, cell13);
                FCGridStringCell cell14 = new FCGridStringCell();
                cell14.setString("0");
                row.addCell(0, cell14);
                FCGridStringCell cell15 = new FCGridStringCell();
                cell15.setString("0");
                row.addCell(0, cell15);
                FCGridStringCell cell16 = new FCGridStringCell();
                cell16.setString("0");
                row.addCell(0, cell16);
                FCGridStringCell cell17 = new FCGridStringCell();
                cell17.setString(data[i].maxMarketOrderVolume.ToString());
                row.addCell(0, cell17);
                FCGridStringCell cell18 = new FCGridStringCell();
                cell18.setString(data[i].maxLimitOrderVolume.ToString());
                row.addCell(0, cell18);
            }
            contractGrid.invalidate();
            contractGrid.invalidate();
        }

        public void setCellStyle2(FCGridCell cell, object value1, object value2)
        {
            double num1 = 0;
            if (value1 != null)
            {
                num1 = FCTran.strToDouble(value1.ToString());
            }
            double num2 = 0;
            if (value2 != null)
            {
                num2 = FCTran.strToDouble(value2.ToString());
            }
            long color = FCColor.rgb(255, 255, 255);
            if (num1 > num2)
            {
                color = FCColor.rgb(255, 0, 0);
            }
            else if (num1 < num2)
            {
                color = FCColor.rgb(0, 255, 0);
            }
            FCGridCellStyle style = cell.m_style;
            if (style == null)
            {
                style = new FCGridCellStyle();
                cell.setStyle(style);
            }
            style.m_textColor = color;
        }


        /// <summary>
        /// 最新数据回调
        /// </summary>
        /// <param name="data">最新数据</param>
        public virtual void onSecurityLatestDataCallBack(List<SecurityLatestData> data, int ctpID)
        {
            FCGrid gridLatestData = getGrid("gridLatestData");
            gridLatestData.setGridLineColor(FCColor.None);
            FCChart chart = getChart("chart");
            FCDataTable dataSource = chart.getDataSource();
            for (int d = 0; d < data.Count; d++)
            {
                FCGridRow row = null;
                for (int i = 0; i < gridLatestData.m_rows.size(); i++)
                {
                    if (gridLatestData.m_rows[i].m_cells[0].getString() == data[d].code)
                    {
                        row = gridLatestData.m_rows[i];
                        break;
                    }
                }
                if (row == null)
                {
                    row = new FCGridRow();
                    row.setHeight(30);
                    gridLatestData.addRow(row);
                    for (int j = 0; j < gridLatestData.m_columns.size(); j++)
                    {
                        FCGridStringCell cell1 = new FCGridStringCell();
                        row.addCell(j, cell1);
                    }
                }
                row.m_cells[0].setString(data[d].code);
                double newVol = 0;
                if (m_allDatas.containsKey(data[d].code))
                {
                    newVol = data[d].volume - m_allDatas[data[d].code].volume;
                }
                m_allDatas.put(data[d].code, data[d]);
                int digit = 0;
                if (m_allCodes.containsKey(data[d].code))
                {
                    row.m_cells[1].setString(m_allCodes[data[d].code].instrumentName);
                    digit = m_allCodes[data[d].code].digit;
                }
                setCellStyle2(row.m_cells[2], row.m_cells[2].getString(), data[d].close);
                row.m_cells[2].setString(FCTran.getValueByDigit(data[d].close, digit));
                double diff = data[d].close - data[d].preSettlementPrice;
                setCellStyle2(row.m_cells[3], diff, 0);
                row.m_cells[3].setString(FCTran.getValueByDigit(diff, digit));
                setCellStyle2(row.m_cells[4], row.m_cells[4].getString(), data[d].bidPrice1);
                row.m_cells[4].setString(FCTran.getValueByDigit(data[d].bidPrice1, digit));
                row.m_cells[5].setString(data[d].bidVolume1.ToString());
                setCellStyle2(row.m_cells[6], row.m_cells[6].getString(), data[d].askPrice1);
                row.m_cells[6].setString(FCTran.getValueByDigit(data[d].askPrice1, digit));
                row.m_cells[7].setString(data[d].askVolume1.ToString());
                row.m_cells[8].setString(data[d].volume.ToString());
                row.m_cells[9].setString(FCTran.getValueByDigit(data[d].openInterest, digit));
                row.m_cells[10].setString(FCTran.getValueByDigit(data[d].upperLimit, digit));
                row.m_cells[11].setString(FCTran.getValueByDigit(data[d].lowerLimit, digit));
                setCellStyle2(row.m_cells[12], row.m_cells[12].getString(), data[d].open);
                row.m_cells[12].setString(FCTran.getValueByDigit(data[d].open, digit));
                row.m_cells[13].setString(FCTran.getValueByDigit(data[d].preSettlementPrice, digit));
                setCellStyle2(row.m_cells[14], row.m_cells[14].getString(), data[d].high);
                row.m_cells[14].setString(FCTran.getValueByDigit(data[d].high, digit));
                setCellStyle2(row.m_cells[15], row.m_cells[15].getString(), data[d].low);
                row.m_cells[15].setString(FCTran.getValueByDigit(data[d].low, digit));
                row.m_cells[16].setString(data[d].bidVolume1.ToString());
                double rangeValue = 0;
                if (data[d].preSettlementPrice != 0)
                {
                    rangeValue = 100 * (data[d].close - data[d].preSettlementPrice) / data[d].preSettlementPrice;
                }
                row.m_cells[17].setString(FCTran.getValueByDigit(rangeValue, 2) + "%");
                setCellStyle2(row.m_cells[17], rangeValue, 0);
                row.m_cells[18].setString(FCTran.getValueByDigit(data[d].preClose, digit));
                row.m_cells[19].setString(data[d].turnover.ToString());
                row.m_cells[20].setString(data[d].exchangeID);
                row.m_cells[21].setString(data[d].updateTime);
                row.m_cells[22].setString(FCTran.getValueByDigit(data[d].preOpenInterest, digit));
                row.m_cells[23].setString(FCTran.getValueByDigit(data[d].close, digit));
                row.m_cells[24].setString(FCTran.getValueByDigit(data[d].settlementPrice, digit));
                row.m_cells[25].setString(FCTran.getValueByDigit(data[d].averagePrice, digit));
                row.m_cells[26].setString("0");
                row.m_cells[27].setString("0");
                row.m_cells[28].setString("0");
                row.m_cells[29].setString("0");
                row.m_cells[30].setString("0");
                row.m_cells[31].setString("0");
                if (newVol > 0)
                {
                    if (data[d].code == m_currentCode)
                    {
                        int rowsSize = dataSource.getRowsCount();
                        dataSource.set(rowsSize + 1, 0, data[d].close);
                        dataSource.set(rowsSize + 1, 1, newVol);
                        chart.update();
                        chart.invalidate();
                    }
                }
            }
            gridLatestData.update();
            gridLatestData.invalidate();
        }

        /// <summary>
        /// 推送的交易信息回调
        /// </summary>
        /// <param name="data">交易信息</param>
        public virtual void onTradeRecordCallBack(TradeRecord data, int ctpID)
        {
            FCGrid gridTradeRecord = getGrid("gridTradeRecord");
            gridTradeRecord.setGridLineColor(FCColor.None);
            FCGridRow row = new FCGridRow();
            row.setHeight(30);
            gridTradeRecord.insertRow(0, row);
            FCGridStringCell cell1 = new FCGridStringCell();
            cell1.setString(data.tradeID);
            row.addCell(0, cell1);
            FCGridStringCell cell2 = new FCGridStringCell();
            cell2.setString(data.code);
            row.addCell(1, cell2);
            FCGridStringCell cell3 = new FCGridStringCell();
            cell3.setString(data.direction);
            row.addCell(2, cell3);
            FCGridStringCell cell4 = new FCGridStringCell();
            cell4.setString(data.offsetFlag);
            row.addCell(3, cell4);
            FCGridStringCell cell5 = new FCGridStringCell();
            cell5.setString(FCTran.getValueByDigit(data.price, 0));
            row.addCell(4, cell5);
            FCGridStringCell cell6 = new FCGridStringCell();
            cell6.setString(FCTran.getValueByDigit(data.volume, 0));
            row.addCell(5, cell6);
            FCGridStringCell cell7 = new FCGridStringCell();
            cell7.setString(data.tradeTime);
            row.addCell(6, cell7);
            FCGridStringCell cell8 = new FCGridStringCell();
            cell8.setString(data.orderSysID);
            row.addCell(7, cell8);
            FCGridStringCell cell9 = new FCGridStringCell();
            cell9.setString("普通成交");
            row.addCell(8, cell9);
            FCGridStringCell cell10 = new FCGridStringCell();
            cell10.setString(data.hedgeFlag);
            row.addCell(9, cell10);
            FCGridStringCell cell11 = new FCGridStringCell();
            cell11.setString(data.exchangeID);
            row.addCell(10, cell11);
            FCGridStringCell cell12 = new FCGridStringCell();
            cell12.setString(data.commission.ToString());
            row.addCell(11, cell12);
            gridTradeRecord.update();
            gridTradeRecord.invalidate();
        }

        /// <summary>
        /// 主动查询的交易信息回调
        /// </summary>
        /// <param name="tradeRecords">交易信息列表</param>
        public virtual void onTradeRecordsCallBack(List<TradeRecord> data, int ctpID)
        {
            FCGrid gridTradeRecord = getGrid("gridTradeRecord");
            gridTradeRecord.setGridLineColor(FCColor.None);
            for (int i = 0; i < data.Count; i++)
            {
                FCGridRow row = new FCGridRow();
                row.setHeight(30);
                gridTradeRecord.insertRow(0, row);
                FCGridStringCell cell1 = new FCGridStringCell();
                cell1.setString(data[i].tradeID);
                row.addCell(0, cell1);
                FCGridStringCell cell2 = new FCGridStringCell();
                cell2.setString(data[i].code);
                row.addCell(1, cell2);
                FCGridStringCell cell3 = new FCGridStringCell();
                cell3.setString(data[i].direction);
                row.addCell(2, cell3);
                FCGridStringCell cell4 = new FCGridStringCell();
                cell4.setString(data[i].offsetFlag);
                row.addCell(3, cell4);
                FCGridStringCell cell5 = new FCGridStringCell();
                cell5.setString(FCTran.getValueByDigit(data[i].price, 0));
                row.addCell(4, cell5);
                FCGridStringCell cell6 = new FCGridStringCell();
                cell6.setString(FCTran.getValueByDigit(data[i].volume, 0));
                row.addCell(5, cell6);
                FCGridStringCell cell7 = new FCGridStringCell();
                cell7.setString(data[i].tradeTime);
                row.addCell(6, cell7);
                FCGridStringCell cell8 = new FCGridStringCell();
                cell8.setString(data[i].orderSysID);
                row.addCell(7, cell8);
                FCGridStringCell cell9 = new FCGridStringCell();
                cell9.setString("普通成交");
                row.addCell(8, cell9);
                FCGridStringCell cell10 = new FCGridStringCell();
                cell10.setString(data[i].hedgeFlag);
                row.addCell(9, cell10);
                FCGridStringCell cell11 = new FCGridStringCell();
                cell11.setString(data[i].exchangeID);
                row.addCell(10, cell11);
                FCGridStringCell cell12 = new FCGridStringCell();
                cell12.setString(data[i].commission.ToString());
                row.addCell(11, cell12);
            }
            gridTradeRecord.update();
            gridTradeRecord.invalidate();
        }

        public int m_ctpID = 0;

        /// <summary>
        /// 登陆到CTP
        /// </summary>
        /// <param name="mdServer">行情地址</param>
        /// <param name="tdServer">交易地址</param>
        /// <param name="brokerID">机构ID</param>
        /// <param name="investorID">投资者ID</param>
        /// <param name="password">密码</param>
        public void loginCTP(String appID, String authCode, String mdServer, String tdServer, String brokerID, String investorID, String password)
        {
            try
            {
                m_ctpID = CTPDLL.create();
                int reqID = CTPDLL.generateReqID(m_ctpID);
                CTPDLL.start(m_ctpID, reqID, appID, authCode, mdServer, tdServer, brokerID, investorID, password);
                while (CTPDLL.isDataOk(m_ctpID) <= 0)
                {
                    Thread.Sleep(1);
                }
                reqID = CTPDLL.generateReqID(m_ctpID);
                CTPDLL.subMarketDatas(m_ctpID, reqID, "cu2301,cu2302,cu2303,rb2301,rb2302,rb2304,ru2301,ru2302,ru2303");
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = 1;
                timer.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            checkCTPData();
        }

        /// <summary>
        /// 运行方法
        /// </summary>
        public void checkCTPData()
        {
            while (CTPDLL.hasNewDatas(m_ctpID) > 0)
            {
                StringBuilder data = new StringBuilder(1024000);
                if (CTPDLL.getDepthMarketData(m_ctpID, data) > 0)
                {
                    List<SecurityLatestData> latestData = CTPConvert.convertToCTPDepthMarketData(data.ToString());
                    onSecurityLatestDataCallBack(latestData, m_ctpID);
                    continue;
                }
                if (CTPDLL.getInstrumentsData(m_ctpID, data) > 0)
                {
                    List<Security> instrumentDatas = CTPConvert.convertToCTPInstrumentDatas(data.ToString());
                    onSecurityCallBack(instrumentDatas, m_ctpID);
                    continue;
                }
                if (CTPDLL.getAccountData(m_ctpID, data) > 0)
                {
                    AccountData accountData = CTPConvert.convertToCTPAccountData(data.ToString());
                    onAccountDataCallBack(accountData, m_ctpID);
                    continue;
                }
                if (CTPDLL.getOrderInfos(m_ctpID, data) > 0)
                {
                    List<OrderInfo> orderInfos = CTPConvert.convertToCTPOrderList(data.ToString());
                    onOrderInfosCallBack(orderInfos, m_ctpID);
                    continue;
                }
                if (CTPDLL.getTradeRecords(m_ctpID, data) > 0)
                {
                    List<TradeRecord> tradeRecords = CTPConvert.convertToCTPTradeRecords(data.ToString());
                    onTradeRecordsCallBack(tradeRecords, m_ctpID);
                    continue;
                }
                if (CTPDLL.getPositionData(m_ctpID, data) > 0)
                {
                    List<InvestorPosition> investorPositions = CTPConvert.convertToCTPInvestorPosition(data.ToString());
                    onInvestorPositionCallBack(investorPositions, m_ctpID);
                    continue;
                }
                if (CTPDLL.getPositionDetailData(m_ctpID, data) > 0)
                {
                    List<InvestorPositionDetail> investorPositionDetails = CTPConvert.convertToCTPInvestorPositionDetail(data.ToString());
                    onInvestorPositionDetailCallBack(investorPositionDetails, m_ctpID);
                    continue;
                }
                if (CTPDLL.getTradeRecord(m_ctpID, data) > 0)
                {
                    TradeRecord tradeRecord = CTPConvert.convertToCTPTrade(data.ToString());
                    onTradeRecordCallBack(tradeRecord, m_ctpID);
                    continue;
                }
                if (CTPDLL.getOrderInfo(m_ctpID, data) > 0)
                {
                    OrderInfo orderInfo = CTPConvert.convertToCTPOrder(data.ToString());
                    onOrderInfoCallBack(orderInfo, m_ctpID);
                    continue;
                }
            }
        }

        public void callGridCellTouchEvent(string eventName, object sender, FCGridCell cell, FCTouchInfo touchInfo, object invoke)
        {
            FCGrid grid = sender as FCGrid;
            String gridName = grid.getName();
            if (gridName == "gridLatestData")
            {
                FCChart chart = getChart("chart");
                chart.clear();
                chart.update();
                String code = cell.getRow().getCell(0).getString();
                m_currentCode = code;
                String price = cell.getRow().getCell(2).getString();
                FCView txtIssueCode = findView("txtIssueCode");
                FCView spinPrice = findView("spinPrice");
                FCView spinVolume = findView("spinVolume");
                txtIssueCode.setText(code);
                spinPrice.setText(price);
                spinVolume.setText("1");
                getNative().invalidate();
            }
            else if (gridName == "gridInvestorPosition")
            {
                String code = cell.getRow().getCell(0).getString();
                FCView txtIssueCode = findView("txtIssueCode");
                FCView spinPrice = findView("spinPrice");
                FCView spinVolume = findView("spinVolume");
                String price = "";
                if (m_allDatas.containsKey(code))
                {
                    price = m_allDatas.get(code).close.ToString();
                }
                txtIssueCode.setText(code);
                spinPrice.setText(price);
                spinVolume.setText("1");
                getNative().invalidate();
            }
            else if (gridName == "gridInvestorPositionDetail")
            {
                String code = cell.getRow().getCell(1).getString();
                FCView txtIssueCode = findView("txtIssueCode");
                FCView spinPrice = findView("spinPrice");
                FCView spinVolume = findView("spinVolume");
                String price = "";
                if (m_allDatas.containsKey(code))
                {
                    price = m_allDatas.get(code).close.ToString();
                }
                txtIssueCode.setText(code);
                spinPrice.setText(price);
                spinVolume.setText("1");
                getNative().invalidate();
            }
        }
    }
}