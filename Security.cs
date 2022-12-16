/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;

namespace ctpstrategy
{
    /// <summary>
    /// CTP资金账户类定义
    /// </summary>
    public class AccountData {
        // 投资者帐号
        public String accountID;
        // 可用资金
        public double available;
        // 期货结算准备金
        public double balance;
        // 经纪公司代码
        public String brokerID;
        // 资金差额
        public double cashIn;
        // 平仓盈亏
        public double closeProfit;
        // 手续费
        public double commission;
        // 信用额度
        public double credit;
        // 币种代码
        public String currencyID;
        // 当前保证金总额
        public double currMargin;
        // 投资者交割保证金
        public double deliveryMargin;
        // 入金金额
        public double deposit;
        // 动态权益(新增)
        public double dynamicBalance;
        // 交易所交割保证金
        public double exchangeDeliveryMargin;
        // 交易所保证金
        public double exchangeMargin;
        //浮动盈亏
        public double floatProfit;
        // 冻结的资金
        public double frozenCash;
        // 冻结的手续费
        public double frozenCommission;
        // 冻结的保证金
        public double frozenMargin;
        // 货币质押余额
        public double fundMortgageAvailable;
        // 货币质入金额
        public double fundMortgageIn;
        // 货币质出金额
        public double fundMortgageOut;
        // 利息收入
        public double interest;
        // 利息基数
        public double interestBase;
        // 质押金额
        public double mortgage;
        // 可质押货币金额
        public double mortgageableFund;
        // 持仓盈亏
        public double positionProfit;
        // 上次结算准备金
        public double preBalance;
        // 上次信用额度
        public double preCredit;
        // 上次存款额
        public double preDeposit;
        // 上次货币质入金额
        public double preFundMortgageIn;
        // 上次货币质出金额
        public double preFundMortgageOut;
        // 上次占用的保证金
        public double preMargin;
        // 上次质押金额
        public double preMortgage;
        // 基本准备金
        public double reserve;
        // 保底期货结算准备金
        public double reserveBalance;
        // 风险度(新增)
        public double risk;
        // 结算编号
        public int settlementID;
        // 特殊产品平仓盈亏
        public double specProductCloseProfit;
        // 特殊产品手续费
        public double specProductCommission;
        // 特殊产品交易所保证金
        public double specProductExchangeMargin;
        // 特殊产品冻结手续费
        public double specProductFrozenCommission;
        // 特殊产品冻结保证金
        public double specProductFrozenMargin;
        // 特殊产品占用保证金
        public double specProductMargin;
        // 特殊产品持仓盈亏
        public double specProductPositionProfit;
        // 根据持仓盈亏算法计算的特殊产品持仓盈亏
        public double specProductPositionProfitByAlg;
        // 交易日
        public String tradingDay;
        // 出金金额
        public double withdraw;
        // 可取资金
        public double withdrawQuota;
    }

    //合约手续费率
    public class CommissionRate {
        //经纪公司代码
        public String brokerID;
        //收费方式
        public String calculateMode;
        //平仓手续费率
        public double closeRatioByMoney;
        //平仓手续费
        public double closeRatioByVolume;
        //平今手续费率
        public double closeTodayRatioByMoney;
        //平今手续费
        public double closeTodayRatioByVolume;
        //平今费
        public double closeTodayFee;
        //合约代码
        public String code;
        //代码
        public String commodityNo;
        //类型
        public String commodityType;
        //交易所编号
        public String exchangeNo;
        //投资者代码
        public String investorID;
        //投资者范围
        public String investorRange;
        //来源
        public String matchSource;
        //开平费
        public double openCloseFee;
        //开仓手续费率
        public double openRatioByMoney;
        //开仓手续费
        public double openRatioByVolume;
    }

    //合约保证金率
    public class MarginRate {
        //经纪公司代码
        public String brokerID;
        //收费方式
        public String calculateMode;
        //看涨看跌标示
        public String callOrPutFlag;
        //合约代码
        public String code;
        //代码
        public String commodityNo;
        //类型
        public String commodityType;
        //合约
        public String contractNo;
        //投机套保标志
        public String hedgeFlag;
        public double initialMargin;
        //投资者代码
        public String investorID;
        //多头保证金率
        public double longMarginRatioByMoney;
        //多头保证金费
        public double longMarginRatioByVolume;
        //投资者范围
        public String investorRange;
        //是否相对交易所收取
        public int isRelativel;
        public double lockMargin;
        public double maintenanceMargin;
        public double sellInitialMargin;
        public double sellMaintenanceMargin;
        //空头保证金率
        public double shortMarginRatioByMoney;
        //空头保证金费
        public double shortMarginRatioByVolume;
        //
        public String strikePrice;
    }

    /// <summary>
    /// 合约数据定义
    /// </summary>
    public class Security {
        // 组合类型
        public String combinationType;
        //创建日
        public String createDate;
        //交割月
        public int deliveryMonth;
        //交割年份
        public int deliveryYear;
        //结束交割日
        public String endDelivDate;
        //交易所代码
        public String exchangeID;
        //合约在交易所的代码
        public String exchangeInstID;
        //到期日
        public String expireDate;
        //保留小数位数
        public int digit;
        //合约生命周期状态
        public String instLifePhase;
        //合约代码
        public String instrumentID;
        //合约名称
        public String instrumentName;
        //当前是否交易
        public String isTrading;
        //多头保证金率
        public double longMarginRatio;
        //限价单最大下单量
        public int maxLimitOrderVolume;
        //是否使用大额单边保证金算法
        public String maxMarginSideAlgorithm;
        //市价单最大下单量
        public int maxMarketOrderVolume;
        //限价单最小下单量
        public int minLimitOrderVolume;
        //市价单最小下单量
        public int minMarketOrderVolume;
        //上市日
        public String openDate;
        //期权类型
        public String optionsType;
        //持仓日期类型
        public String positionDateType;
        //持仓类型
        public String positionType;
        //最小变动价位
        public double priceTick;
        //产品类型
        public String productClass;
        //产品代码
        public String productID;
        //空头保证金率
        public double shortMarginRatio;
        //开始交割日
        public String startDelivDate;
        //执行价
        public double strikePrice;
        //基础商品代码
        public String underlyingInstrID;
        //基础商品名称
        public String underlyingInstrName;
        //合约基础商品乘数
        public double underlyingMultiple;
        //合约数量乘数
        public int volumeMultiple;

        /// <summary>
        /// 获取基础商品名称
        /// </summary>
        public void getNnderlyingInstrName() {
            int size = instrumentName.Length;
            underlyingInstrName = "";
            foreach (char sz in instrumentName) {
                if (!(sz == '0' || sz == '1' || sz == '2' || sz == '3' || sz == '4' ||
                    sz == '5' || sz == '6' || sz == '7' || sz == '8' || sz == '9')) {
                    underlyingInstrName += sz.ToString();
                }
            }
        }
    }

    /// <summary>
    /// 投资者持仓定义
    /// </summary>
    public class InvestorPosition {
        //放弃执行冻结
        public int abandonFrozen;
        // 经纪公司代码
        public String brokerID;
        // 资金差额
        public double cashIn;
        // 平仓金额
        public double closeAmount;
        // 平仓盈亏
        public double closeProfit;
        // 逐日盯市平仓盈亏
        public double closeProfitByDate;
        // 逐笔对冲平仓盈亏
        public double closeProfitByTrade;
        // 平仓量
        public int closeVolume;
        // 合约代码
        public String code;
        // 组合多头冻结
        public int combLongFrozen;
        // 组合成交形成的持仓
        public int combPosition;
        // 组合空头冻结
        public int combShortFrozen;
        // 手续费
        public double commission;
        // 交易所保证金
        public double exchangeMargin;
        //浮动盈亏
        public double floatProfit;
        // 冻结的资金
        public double frozenCash;
        // 冻结的手续费
        public double frozenCommission;
        // 冻结的保证金
        public double frozenMargin;
        // 投机套保标志
        public String hedgeFlag;
        // 投资者代码
        public String investorID;
        // 多头冻结
        public int longFrozen;
        // 多头冻结金额
        public double longFrozenAmount;
        //保证金
        public double margin;
        // 保证金率
        public double marginRateByMoney;
        // 保证金率(按手数)
        public double marginRateByVolume;
        // 开仓金额
        public double openAmount;
        // 开仓成本
        public double openCost;
        //开仓价格
        public double openPrice;
        // 开仓量
        public int openVolume;
        // 今日持仓
        public int position;
        // 持仓日期
        public String positionDate;
        // 持仓多空方向
        public String posiDirection;
        // 持仓成本
        public double positionCost;
        // 持仓盈亏
        public double positionProfit;
        // 上次占用的保证金
        public double preMargin;
        // 上次结算价
        public double preSettlementPrice;
        // 结算编号
        public int settlementID;
        // 本次结算价
        public double settlementPrice;
        // 空头冻结
        public int shortFrozen;
        // 空头冻结金额
        public double shortFrozenAmount;
        // 执行冻结
        public int strikeFrozen;
        // 执行冻结金额
        public double strikeFrozenAmount;
        // 今日持仓
        public int todayPosition;
        //交易日
        public String tradingDate;
        //占用的保证金
        public double useMargin;
        //上日持仓
        public int ydPosition;

        /// <summary>
        /// 获取可用仓位
        /// </summary>
        public int getAvailablePosition() {
            int position = 0;
            position = position - getFrozenAmount();
            return position;
        }

        /// <summary>
        /// 获取组合冻结量
        /// </summary>
        /// <returns></returns>
        public int getFrozenAmount() {
            int position = 0;
            if (posiDirection == "多") {
                position = longFrozen;
            }
            else if (posiDirection == "空") {
                position = shortFrozen;
            }
            return position;
        }
    }

    /// <summary>
    /// 持仓明细
    /// </summary>
    public class InvestorPositionDetail {
        //经纪公司代码
        public String brokerID;
        //平仓金额
        public double closeAmount;
        //平仓盈亏
        public double closeProfit;
        //逐日盯市持仓盈亏
        public double closeProfitByDate;
        //逐笔对冲持仓盈亏
        public double closeProfitByTrade;
        //平仓量
        public double closeVolume;
        //合约代码
        public String code;
        //组合合约代码
        public String combInstrumentID;
        //买卖
        public String direction;
        //交易所代码
        public String exchangeID;
        //交易所保证金
        public double exchMargin;
        //浮动盈亏
        public double floatProfit;
        //投机套保标志
        public String hedgeFlag;
        //投资者代码
        public String investorID;
        //昨收盘
        public double lastPrice;
        //昨结算价
        public double lastSettlementPrice;
        //投资者保证金
        public double margin;
        //保证金率
        public double marginRateByMoney;
        //保证金率(按手数)
        public double marginRateByVolume;
        //内部编号
        public String orderRef;
        //开仓日期
        public String openDate;
        //开仓价
        public double openPrice;
        //开仓量
        public int openVolume;
        //本地持仓号，服务器编写
        public String positionNo;
        //持仓盈亏
        public double positionProfit;
        //逐日盯市持仓利润
        public double positionProfitByDate;
        //逐笔对冲持仓利润
        public double positionProfitByTrade;
        //持仓流号
        public int positionStreamId;
        //昨结算价
        public double preSettlementPrice;
        //持仓盈亏基准价
        public double profitBasePrice;
        //结算编号
        public int settlementID;
        //结算价
        public double settlementPrice;
        //成交日期
        public String tradingDay;
        //成交编号
        public String tradeID;
        //成交类型
        public String tradeType;
        //数量
        public int volume;
    }

    /// <summary>
    /// 报单定义
    /// </summary>
    public class OrderInfo {
        //激活时间	
        public String activeTime;
        //最后修改交易所交易员代码	
        public String activeTraderID;
        //操作用户代码	
        public String activeUserID;
        //经纪公司代码	
        public String brokerID;
        //经纪公司报单编号	
        public int brokerOrderSeq;
        //业务单元	
        public String businessUnit;
        //撤销时间	
        public String cancelTime;
        //结算会员编号	
        public String clearingPartID;
        //客户代码	
        public String clientID;
        //合约代码	
        public String code;
        //组合投机套保标志	
        public String combHedgeFlag;
        //组合开平标志	
        public String combOffsetFlag;
        //触发条件	
        public String contingentCondition;
        //买卖方向	
        public String direction;
        //交易所代码	
        public String exchangeID;
        //合约在交易所的代码	
        public String exchangeInstID;
        //强平原因	
        public String forceCloseReason;
        //前置编号	
        public int frontID;
        //GTD日期	
        public String gTDDate;
        //价格	
        public double limitPrice;
        //报单日期	
        public String insertDate;
        //委托时间	
        public String insertTime;
        //安装编号	
        public String installID;
        //投资者代码	
        public String investorID;
        //自动挂起标志	
        public int isAutoSuspend;
        //互换单标志	
        public int isSwapOrder;
        //最小成交量	
        public int minVolume;
        //报单提示序号	
        public int notifySequence;
        //本地报单编号	
        public String orderLocalID;
        //报单价格条件	
        public String orderPriceType;
        //报单引用	
        public String orderRef;
        //报单状态	
        public String orderStatus;
        //报单来源	
        public String orderSource;
        //报单提交状态	
        public String orderSubmitStatus;
        //报单编号	
        public String orderSysID;
        //报单类型	
        public String orderType;
        //会员代码	
        public String participantID;
        //相关报单	
        public String relativeOrderSysID;
        //请求编号	
        public int requestID;
        //序号	
        public int sequenceNo;
        //会话编号	
        public int sessionID;
        //结算编号	
        public int settlementID;
        //状态信息	
        public String statusMsg;
        //止损价	
        public double stopPrice;
        //挂起时间	
        public String suspendTime;
        //有效期类型	
        public String timeCondition;
        //交易所交易员代码	
        public String traderID;
        //交易日	
        public String tradingDay;
        //最后修改时间	
        public String updateTime;
        //用户强评标志	
        public int userForceClose;
        //用户代码	
        public String userID;
        //用户端产品信息	
        public String userProductInfo;
        //成交量类型	
        public String volumeCondition;
        //剩余数量	
        public int volumeTotal;
        //数量	
        public int volumeTotalOriginal;
        //今成交数量	
        public int volumeTraded;
        //郑商所成交数量	
        public int zCETotalTradedVolume;
    }

    //最新数据
    public class SecurityLatestData {
        //触发日
        public String actionDay;
        //卖1价
        public double askPrice1;
        //卖2价
        public double askPrice2;
        //卖3价
        public double askPrice3;
        //卖4价
        public double askPrice4;
        //卖5价
        public double askPrice5;
        //卖1量
        public int askVolume1;
        //卖2量
        public int askVolume2;
        //卖3量
        public int askVolume3;
        //卖4量
        public int askVolume4;
        //卖5量
        public int askVolume5;
        //平均价格
        public double averagePrice;
        //买1价
        public double bidPrice1;
        //买2价
        public double bidPrice2;
        //买3价
        public double bidPrice3;
        //买4价
        public double bidPrice4;
        //买5价
        public double bidPrice5;
        //买1量
        public int bidVolume1;
        //买2量
        public int bidVolume2;
        //买3量
        public int bidVolume3;
        //买4量
        public int bidVolume4;
        //买5量
        public int bidVolume5;
        //最新价
        public double close;
        //合约代码
        public String code;
        //今虚实度
        public double currDelta;
        //交易所ID
        public String exchangeID;
        //交易所InstID
        public String exchangeInstID;
        //最高价
        public double high;
        //昨日收盘价
        public double lastClose;
        //最低价
        public double low;
        //跌停价
        public double lowerLimit;
        //开盘价
        public double open;
        //持仓量
        public double openInterest;
        //昨收盘
        public double preClose;
        //昨虚实度
        public double preDelta;
        //昨持仓量
        public double preOpenInterest;
        //上次结算价
        public double preSettlementPrice;
        //本次结算价
        public double settlementPrice;
        //交易日
        public String tradingDay;
        //成交金额
        public double turnover;
        //最后修改毫秒
        public int updateMillisec;
        //最后修改时间
        public String updateTime;
        //涨停价
        public double upperLimit;
        //成交量
        public int volume;
    }

    /// <summary>
    /// 历史数据
    /// </summary>
    public class SecurityData {
        /// <summary>
        /// 收盘价
        /// </summary>
        public double close;
        /// <summary>
        /// 日期
        /// </summary>
        public String date;

        /// <summary>
        /// 数值日期
        /// </summary>
        public double doubleDate;

        /// <summary>
        /// 最高价
        /// </summary>
        public double high;
        /// <summary>
        /// 最低价
        /// </summary>
        public double low;
        /// <summary>
        /// 均价
        /// </summary>
        public double ma;
        /// <summary>
        /// 开盘价
        /// </summary>
        public double open;

        public double volume;
    }

    /// <summary>
    /// CTP交易定义
    /// </summary>
    public class TradeRecord {
        //经纪公司代码
        public String brokerID;
        ///经纪公司报单编号
        public int brokerOrderSeq;
        ///业务单元
        public String businessUnit;
        ///结算会员编号
        public String clearingPartID;
        ///客户代码
        public String clientID;
        //合约代码
        public String code;
        //手续费
        public double commission;
        //买卖方向
        public String direction;
        //市场代码
        public String exchangeID;
        //合约在交易所的代码
        public String exchangeInstID;
        //投机套保标志
        public String hedgeFlag;
        //投资者代码
        public String investorID;
        //开平标志
        public String offsetFlag;
        //本地报单编号
        public String orderLocalID;
        //报单引用
        public String orderRef;
        //报单编号
        public String orderSysID;
        //会员代码
        public String participantID;
        //价格
        public double price;
        //成交价来源
        public String priceSource;
        //序号
        public int sequenceNo;
        //结算编号
        public int settlementID;
        //成交编号
        public String tradeID;
        //交易所交易员代码
        public string traderID;
        //成交时期
        public String tradeDate;
        //成交来源
        public String tradeSource;
        //成交时间
        public String tradeTime;
        //交易日
        public String tradingDay;
        //成交类型
        public String tradeType;
        //交易角色
        public String tradingRole;
        //数量
        public int volume;
        //用户代码
        public String userID;
    }

    /// <summary>
    /// 数据转换
    /// </summary>
    public class CTPConvert {

        /// <summary>
        /// 转换成CTP资金账户
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP资金账户</returns>
        public static AccountData convertToCTPAccountData(String result) {
            //资金账号信息返回
            String[] results = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            AccountData cTPTradingAccount = new AccountData();
            int i = 0;
            ///经纪公司代码
            cTPTradingAccount.brokerID = results[i++];
            ///投资者帐号
            cTPTradingAccount.accountID = results[i++];
            ///上次质押金额
            cTPTradingAccount.preMortgage = FCTran.strToDouble(results[i++]);
            ///上次信用额度
            cTPTradingAccount.preCredit = FCTran.strToDouble(results[i++]);
            ///上次存款额
            cTPTradingAccount.preDeposit = FCTran.strToDouble(results[i++]);
            ///上次结算准备金
            cTPTradingAccount.preBalance = FCTran.strToDouble(results[i++]);
            ///上次占用的保证金
            cTPTradingAccount.preMargin = FCTran.strToDouble(results[i++]);
            ///利息基数
            cTPTradingAccount.interestBase = FCTran.strToDouble(results[i++]);
            ///利息收入
            cTPTradingAccount.interest = FCTran.strToDouble(results[i++]);
            ///入金金额
            cTPTradingAccount.deposit = FCTran.strToDouble(results[i++]);
            ///出金金额
            cTPTradingAccount.withdraw = FCTran.strToDouble(results[i++]);
            ///冻结的保证金
            cTPTradingAccount.frozenMargin = FCTran.strToDouble(results[i++]);
            ///冻结的资金
            cTPTradingAccount.frozenCash = FCTran.strToDouble(results[i++]);
            ///冻结的手续费
            cTPTradingAccount.frozenCommission = FCTran.strToDouble(results[i++]);
            ///当前保证金总额
            cTPTradingAccount.currMargin = FCTran.strToDouble(results[i++]);
            ///资金差额
            cTPTradingAccount.cashIn = FCTran.strToDouble(results[i++]);
            ///手续费
            cTPTradingAccount.commission = FCTran.strToDouble(results[i++]);
            ///平仓盈亏
            cTPTradingAccount.closeProfit = FCTran.strToDouble(results[i++]);
            ///持仓盈亏
            cTPTradingAccount.positionProfit = FCTran.strToDouble(results[i++]);
            ///期货结算准备金
            cTPTradingAccount.balance = FCTran.strToDouble(results[i++]);
            ///可用资金
            cTPTradingAccount.available = FCTran.strToDouble(results[i++]);
            ///可取资金
            cTPTradingAccount.withdrawQuota = FCTran.strToDouble(results[i++]);
            ///基本准备金
            cTPTradingAccount.reserve = FCTran.strToDouble(results[i++]);
            ///交易日
            cTPTradingAccount.tradingDay = results[i++];
            ///结算编号
            cTPTradingAccount.settlementID = FCTran.strToInt(results[i++]);
            ///信用额度
            cTPTradingAccount.credit = FCTran.strToDouble(results[i++]);
            ///质押金额
            cTPTradingAccount.mortgage = FCTran.strToDouble(results[i++]);
            ///交易所保证金
            cTPTradingAccount.exchangeMargin = FCTran.strToDouble(results[i++]);
            ///投资者交割保证金
            cTPTradingAccount.deliveryMargin = FCTran.strToDouble(results[i++]);
            ///交易所交割保证金
            cTPTradingAccount.exchangeDeliveryMargin = FCTran.strToDouble(results[i++]);
            ///保底期货结算准备金
            cTPTradingAccount.reserveBalance = FCTran.strToDouble(results[i++]);
            ///币种代码
            cTPTradingAccount.currencyID = results[i++];
            ///上次货币质入金额
            cTPTradingAccount.preFundMortgageIn = FCTran.strToDouble(results[i++]);
            ///上次货币质出金额
            cTPTradingAccount.preFundMortgageOut = FCTran.strToDouble(results[i++]);
            ///货币质入金额
            cTPTradingAccount.fundMortgageIn = FCTran.strToDouble(results[i++]);
            ///货币质出金额
            cTPTradingAccount.fundMortgageOut = FCTran.strToDouble(results[i++]);
            ///货币质押余额
            cTPTradingAccount.fundMortgageAvailable = FCTran.strToDouble(results[i++]);
            ///可质押货币金额
            cTPTradingAccount.mortgageableFund = FCTran.strToDouble(results[i++]);
            ///特殊产品占用保证金
            cTPTradingAccount.specProductMargin = FCTran.strToDouble(results[i++]);
            ///特殊产品冻结保证金
            cTPTradingAccount.specProductFrozenMargin = FCTran.strToDouble(results[i++]);
            ///特殊产品手续费
            cTPTradingAccount.specProductCommission = FCTran.strToDouble(results[i++]);
            ///特殊产品冻结手续费
            cTPTradingAccount.specProductFrozenCommission = FCTran.strToDouble(results[i++]);
            ///特殊产品持仓盈亏
            cTPTradingAccount.specProductPositionProfit = FCTran.strToDouble(results[i++]);
            ///特殊产品平仓盈亏
            cTPTradingAccount.specProductCloseProfit = FCTran.strToDouble(results[i++]);
            ///根据持仓盈亏算法计算的特殊产品持仓盈亏
            cTPTradingAccount.specProductPositionProfitByAlg = FCTran.strToDouble(results[i++]);
            ///特殊产品交易所保证金
            cTPTradingAccount.specProductExchangeMargin = FCTran.strToDouble(results[i++]);
            ///动态权益
            cTPTradingAccount.dynamicBalance = FCTran.strToDouble(results[i++]);
            ///风险度
            cTPTradingAccount.risk = FCTran.strToDouble(results[i++]);
            //浮动盈亏
            cTPTradingAccount.floatProfit = FCTran.strToDouble(results[i++]);
            return cTPTradingAccount;
        }

        /// <summary>
        /// 转换成CTP手续费率
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP手续费率</returns>
        public static CommissionRate convertToCTPCommissionRate(String result) {
            String[] results = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int i = 0;
            CommissionRate cTPCommissionRate = new CommissionRate();
            cTPCommissionRate.code = results[i++];
            cTPCommissionRate.investorRange = results[i++];
            cTPCommissionRate.brokerID = results[i++];
            cTPCommissionRate.investorID = results[i++];
            cTPCommissionRate.openRatioByMoney = FCTran.strToDouble(results[i++]);
            cTPCommissionRate.openRatioByVolume = FCTran.strToDouble(results[i++]);
            cTPCommissionRate.closeRatioByMoney = FCTran.strToDouble(results[i++]);
            cTPCommissionRate.closeRatioByVolume = FCTran.strToDouble(results[i++]);
            cTPCommissionRate.closeTodayRatioByMoney = FCTran.strToDouble(results[i++]);
            cTPCommissionRate.closeTodayRatioByVolume = FCTran.strToDouble(results[i++]);
            return cTPCommissionRate;
        }

        /// <summary>
        /// 转换CTP合约信息
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>合约信息</returns>
        public static List<Security> convertToCTPInstrumentDatas(String result) {
            String[] strs = result.ToString().Split(new String[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            int size = strs.Length;
            List<Security> cTPInstrumentDatas = new List<Security>();
            for (int i = 0; i < size; i++) {
                String[] results = strs[i].Split(new char[] { ',' });
                Security cTPInstrumentData = new Security();
                int j = 0;
                ///合约代码
                cTPInstrumentData.instrumentID = results[j++];
                ///交易所代码
                cTPInstrumentData.exchangeID = results[j++];
                ///合约名称
                cTPInstrumentData.instrumentName = results[j++];
                ///合约在交易所的代码
                cTPInstrumentData.exchangeInstID = results[j++];
                ///产品代码
                cTPInstrumentData.productID = results[j++];
                ///产品类型
                cTPInstrumentData.productClass = results[j++];
                ///交割年份
                cTPInstrumentData.deliveryYear = FCTran.strToInt(results[j++]);
                ///交割月
                cTPInstrumentData.deliveryMonth = FCTran.strToInt(results[j++]);
                ///市价单最大下单量
                cTPInstrumentData.maxMarketOrderVolume = FCTran.strToInt(results[j++]);
                ///市价单最小下单量
                cTPInstrumentData.minMarketOrderVolume = FCTran.strToInt(results[j++]);
                ///限价单最大下单量
                cTPInstrumentData.maxLimitOrderVolume = FCTran.strToInt(results[j++]);
                ///限价单最小下单量
                cTPInstrumentData.minLimitOrderVolume = FCTran.strToInt(results[j++]);
                ///合约数量乘数
                cTPInstrumentData.volumeMultiple = FCTran.strToInt(results[j++]);
                ///最小变动价位
                cTPInstrumentData.priceTick = FCTran.strToDouble(results[j++]);
                ///创建日
                cTPInstrumentData.createDate = results[j++];
                ///上市日
                cTPInstrumentData.openDate = results[j++];
                ///到期日
                cTPInstrumentData.expireDate = results[j++];
                ///开始交割日
                cTPInstrumentData.startDelivDate = results[j++];
                ///结束交割日
                cTPInstrumentData.endDelivDate = results[j++];
                ///合约生命周期状态
                cTPInstrumentData.instLifePhase = results[j++];
                ///当前是否交易
                cTPInstrumentData.isTrading = results[j++];
                ///持仓类型
                cTPInstrumentData.positionType = results[j++];
                ///持仓日期类型
                cTPInstrumentData.positionDateType = results[j++];
                ///多头保证金率   
                cTPInstrumentData.longMarginRatio = FCTran.strToDouble(results[j++]);
                ///空头保证金率
                cTPInstrumentData.shortMarginRatio = FCTran.strToDouble(results[j++]);
                ///是否使用大额单边保证金算法
                cTPInstrumentData.maxMarginSideAlgorithm = results[j++];
                ///基础商品代码
                cTPInstrumentData.underlyingInstrID = results[j++];
                ///执行价
                cTPInstrumentData.strikePrice = FCTran.strToDouble(results[j++]);
                ///期权类型
                cTPInstrumentData.optionsType = results[j++];
                ///合约基础商品乘数
                cTPInstrumentData.underlyingMultiple = FCTran.strToDouble(results[j++]);
                ///组合类型
                cTPInstrumentData.combinationType = results[j++];
                cTPInstrumentData.getNnderlyingInstrName();
                cTPInstrumentDatas.Add(cTPInstrumentData);
            }
            return cTPInstrumentDatas;
        }

        /// <summary>
        /// 转换CTP深度市场数据
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP深度市场数据</returns>
        public static List<SecurityLatestData> convertToCTPDepthMarketData(String result) {
            String[] strs = result.ToString().Split(new String[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            int size = strs.Length;
            List<SecurityLatestData> cTPLatestDatas = new List<SecurityLatestData>();
            for (int p = 0; p < size; p++) {
                //持仓信息返回
                String[] results = strs[p].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                SecurityLatestData cTPDepthMarketData = new SecurityLatestData();
                int i = 0;
                cTPDepthMarketData.tradingDay = results[i++];
                cTPDepthMarketData.code = results[i++];
                String exchangeID = results[i++];
                String exchangeInstID = results[i++];
                cTPDepthMarketData.close = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.preSettlementPrice = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.preClose = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.preOpenInterest = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.open = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.high = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.low = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.volume = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.turnover = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.openInterest = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.lastClose = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.settlementPrice = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.upperLimit = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.lowerLimit = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.preDelta = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.currDelta = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.updateTime = results[i++];
                cTPDepthMarketData.updateMillisec = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.bidPrice1 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.bidVolume1 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.askPrice1 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.askVolume1 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.bidPrice2 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.bidVolume2 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.askPrice2 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.askVolume2 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.bidPrice3 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.bidVolume3 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.askPrice3 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.askVolume3 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.bidPrice4 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.bidVolume4 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.askPrice4 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.askVolume4 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.bidPrice5 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.bidVolume5 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.askPrice5 = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.askVolume5 = FCTran.strToInt(results[i++]);
                cTPDepthMarketData.averagePrice = FCTran.strToDouble(results[i++]);
                cTPDepthMarketData.actionDay = results[i++];
                cTPLatestDatas.Add(cTPDepthMarketData);
            }
            return cTPLatestDatas;
        }

        /// <summary>
        /// 转换CTP持仓信息
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP持仓信息</returns>
        public static List<InvestorPosition> convertToCTPInvestorPosition(String result) {
            List<InvestorPosition> list = new List<InvestorPosition>();
            //报单信息返回
            String[] strs = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int p = 0; p < strs.Length; p++) {
                //持仓信息返回
                String[] results = strs[p].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                InvestorPosition cTPInvestorPosition = new InvestorPosition();
                int i = 0;
                ///合约代码
                cTPInvestorPosition.code = results[i++];
                ///经纪公司代码
                cTPInvestorPosition.brokerID = results[i++];
                ///投资者代码
                cTPInvestorPosition.investorID = results[i++];
                ///持仓多空方向
                cTPInvestorPosition.posiDirection = results[i++];
                ///投机套保标志
                cTPInvestorPosition.hedgeFlag = results[i++];
                ///持仓日期
                cTPInvestorPosition.positionDate = results[i++];
                ///上日持仓
                cTPInvestorPosition.ydPosition = FCTran.strToInt(results[i++]);
                ///今日持仓
                cTPInvestorPosition.position = FCTran.strToInt(results[i++]);
                ///多头冻结
                cTPInvestorPosition.longFrozen = FCTran.strToInt(results[i++]);
                ///空头冻结
                cTPInvestorPosition.shortFrozen = FCTran.strToInt(results[i++]);
                ///开仓冻结金额
                cTPInvestorPosition.longFrozenAmount = FCTran.strToDouble(results[i++]);
                ///开仓冻结金额
                cTPInvestorPosition.shortFrozenAmount = FCTran.strToDouble(results[i++]);
                ///开仓量
                cTPInvestorPosition.openVolume = FCTran.strToInt(results[i++]);
                ///平仓量
                cTPInvestorPosition.closeVolume = FCTran.strToInt(results[i++]);
                ///开仓金额
                cTPInvestorPosition.openAmount = FCTran.strToDouble(results[i++]);
                ///平仓金额
                cTPInvestorPosition.closeAmount = FCTran.strToDouble(results[i++]);
                ///持仓成本
                cTPInvestorPosition.positionCost = FCTran.strToDouble(results[i++]);
                ///上次占用的保证金
                cTPInvestorPosition.preMargin = FCTran.strToDouble(results[i++]);
                ///占用的保证金
                cTPInvestorPosition.useMargin = FCTran.strToDouble(results[i++]);
                ///冻结的保证金
                cTPInvestorPosition.frozenMargin = FCTran.strToDouble(results[i++]);
                ///冻结的资金
                cTPInvestorPosition.frozenCash = FCTran.strToDouble(results[i++]);
                ///冻结的手续费
                cTPInvestorPosition.frozenCommission = FCTran.strToDouble(results[i++]);
                ///资金差额
                cTPInvestorPosition.cashIn = FCTran.strToDouble(results[i++]);
                ///手续费
                cTPInvestorPosition.margin = FCTran.strToDouble(results[i++]);
                ///平仓盈亏
                cTPInvestorPosition.floatProfit = FCTran.strToDouble(results[i++]);
                ///持仓盈亏
                cTPInvestorPosition.positionProfit = FCTran.strToDouble(results[i++]);
                ///上次结算价
                cTPInvestorPosition.preSettlementPrice = FCTran.strToDouble(results[i++]);
                ///本次结算价
                cTPInvestorPosition.settlementPrice = FCTran.strToDouble(results[i++]);
                ///交易日
                cTPInvestorPosition.tradingDate = results[i++];
                ///结算编号
                cTPInvestorPosition.settlementID = FCTran.strToInt(results[i++]);
                ///开仓成本
                cTPInvestorPosition.openCost = FCTran.strToDouble(results[i++]);
                ///交易所保证金
                cTPInvestorPosition.exchangeMargin = FCTran.strToDouble(results[i++]);
                ///组合成交形成的持仓
                cTPInvestorPosition.combPosition = FCTran.strToInt(results[i++]);
                ///组合多头冻结
                cTPInvestorPosition.combLongFrozen = FCTran.strToInt(results[i++]);
                ///组合空头冻结
                cTPInvestorPosition.combShortFrozen = FCTran.strToInt(results[i++]);
                ///逐日盯市平仓盈亏
                cTPInvestorPosition.closeProfitByDate = FCTran.strToDouble(results[i++]);
                ///逐笔对冲平仓盈亏
                cTPInvestorPosition.closeProfitByTrade = FCTran.strToDouble(results[i++]);
                ///今日持仓
                cTPInvestorPosition.todayPosition = FCTran.strToInt(results[i++]);
                ///保证金率
                cTPInvestorPosition.marginRateByMoney = FCTran.strToDouble(results[i++]);
                ///保证金率(按手数)
                cTPInvestorPosition.marginRateByVolume = FCTran.strToDouble(results[i++]);
                ///执行冻结
                cTPInvestorPosition.strikeFrozen = FCTran.strToInt(results[i++]);
                ///执行冻结金额
                cTPInvestorPosition.strikeFrozenAmount = FCTran.strToDouble(results[i++]);
                ///放弃执行冻结
                cTPInvestorPosition.abandonFrozen = FCTran.strToInt(results[i++]);
                //开仓均价
                cTPInvestorPosition.openPrice = FCTran.strToInt(results[i++]);
                list.Add(cTPInvestorPosition);
            }
            return list;
        }

        /// <summary>
        /// 转换CTP持仓明细信息
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP明细持仓信息</returns>
        public static List<InvestorPositionDetail> convertToCTPInvestorPositionDetail(String result) {
            List<InvestorPositionDetail> list = new List<InvestorPositionDetail>();
            //报单信息返回
            String[] strs = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int p = 0; p < strs.Length; p++) {
                //持仓信息返回
                String[] results = strs[p].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                InvestorPositionDetail cTPInvestorPositionDetail = new InvestorPositionDetail();
                int i = 0;
                cTPInvestorPositionDetail.code = results[i++];
                cTPInvestorPositionDetail.brokerID = results[i++];
                cTPInvestorPositionDetail.investorID = results[i++];
                cTPInvestorPositionDetail.hedgeFlag = results[i++];
                cTPInvestorPositionDetail.direction = results[i++];
                cTPInvestorPositionDetail.openDate = results[i++];
                cTPInvestorPositionDetail.tradeID = results[i++];
                cTPInvestorPositionDetail.volume = FCTran.strToInt(results[i++]);
                cTPInvestorPositionDetail.openPrice = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.tradingDay = results[i++];
                cTPInvestorPositionDetail.settlementID = FCTran.strToInt(results[i++]);
                cTPInvestorPositionDetail.tradeType = results[i++];
                cTPInvestorPositionDetail.combInstrumentID = results[i++];
                cTPInvestorPositionDetail.exchangeID = results[i++];
                cTPInvestorPositionDetail.closeProfitByDate = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.closeProfitByTrade = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.positionProfitByDate = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.positionProfitByTrade = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.margin = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.exchMargin = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.marginRateByMoney = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.marginRateByVolume = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.lastSettlementPrice = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.lastSettlementPrice = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.settlementPrice = FCTran.strToDouble(results[i++]);
                cTPInvestorPositionDetail.closeVolume = FCTran.strToInt(results[i++]);
                list.Add(cTPInvestorPositionDetail);
            }
            return list;
        }

        /// <summary>
        /// 转换CTP保证金率
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP保证金率</returns>
        public static MarginRate convertToCTPMarginRate(String result) {
            String[] results = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            MarginRate cTPMarginRate = null;
            int i = 0;
            cTPMarginRate = new MarginRate();
            cTPMarginRate.code = results[i++];
            cTPMarginRate.brokerID = results[i++];
            cTPMarginRate.investorID = results[i++];
            cTPMarginRate.hedgeFlag = results[i++];
            cTPMarginRate.longMarginRatioByMoney = FCTran.strToDouble(results[i++]);
            cTPMarginRate.longMarginRatioByVolume = FCTran.strToDouble(results[i++]);
            cTPMarginRate.shortMarginRatioByMoney = FCTran.strToDouble(results[i++]);
            cTPMarginRate.shortMarginRatioByVolume = FCTran.strToDouble(results[i++]);
            cTPMarginRate.isRelativel = FCTran.strToInt(results[i++]);
            return cTPMarginRate;
        }

        /// <summary>
        /// 转换CTP报单信息
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP报单信息</returns>
        public static List<OrderInfo> convertToCTPOrderList(String result) {
            List<OrderInfo> lst = new List<OrderInfo>();
            //报单信息返回
            String[] results = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < results.Length; i++) {
                OrderInfo order = convertToCTPOrder(results[i]);
                if (order != null) {
                    lst.Add(order);
                }
            }
            return lst;
        }

        /// <summary>
        /// 转换CTP报单信息
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP报单信息</returns>
        public static OrderInfo convertToCTPOrder(String result) {
            //报单信息返回
            String[] results = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            OrderInfo cTPOrder = null;
            cTPOrder = new OrderInfo();
            int i = 0;
            ///经纪公司代码
            cTPOrder.brokerID = results[i++];
            ///投资者代码
            cTPOrder.investorID = results[i++];
            ///合约代码
            cTPOrder.code = results[i++];
            ///报单引用
            cTPOrder.orderRef = results[i++];
            ///用户代码
            cTPOrder.userID = results[i++];
            ///报单价格条件
            cTPOrder.orderPriceType = results[i++];
            ///买卖方向
            cTPOrder.direction = results[i++];
            ///组合开平标志
            cTPOrder.combOffsetFlag = results[i++];
            ///组合投机套保标志
            cTPOrder.combHedgeFlag = results[i++];
            ///价格
            cTPOrder.limitPrice = FCTran.strToDouble(results[i++]);
            ///数量
            cTPOrder.volumeTotalOriginal = FCTran.strToInt(results[i++]);
            ///有效期类型
            cTPOrder.timeCondition = results[i++];
            ///GTD日期
            cTPOrder.gTDDate = results[i++];
            ///成交量类型
            cTPOrder.volumeCondition = results[i++];
            ///最小成交量
            cTPOrder.minVolume = FCTran.strToInt(results[i++]);
            ///触发条件
            cTPOrder.contingentCondition = results[i++];
            ///止损价
            cTPOrder.stopPrice = FCTran.strToDouble(results[i++]);
            ///强平原因
            cTPOrder.forceCloseReason = results[i++];
            ///自动挂起标志
            cTPOrder.isAutoSuspend = FCTran.strToInt(results[i++]);
            ///业务单元
            cTPOrder.businessUnit = results[i++];
            ///请求编号
            cTPOrder.requestID = FCTran.strToInt(results[i++]);
            ///本地报单编号
            cTPOrder.orderLocalID = results[i++];
            ///交易所代码
            cTPOrder.exchangeID = results[i++];
            ///会员代码
            cTPOrder.participantID = results[i++];
            ///客户代码
            cTPOrder.clientID = results[i++];
            ///合约在交易所的代码
            cTPOrder.exchangeInstID = results[i++];
            ///交易所交易员代码
            cTPOrder.traderID = results[i++];
            ///安装编号
            cTPOrder.installID = results[i++];
            ///报单提交状态
            cTPOrder.orderSubmitStatus = results[i++];
            ///报单提示序号
            cTPOrder.notifySequence = FCTran.strToInt(results[i++]);
            ///交易日
            cTPOrder.tradingDay = results[i++];
            ///结算编号
            cTPOrder.settlementID = FCTran.strToInt(results[i++]);
            ///报单编号
            cTPOrder.orderSysID = results[i++];
            ///报单来源
            cTPOrder.orderSource = results[i++];
            ///报单状态
            cTPOrder.orderStatus = results[i++];
            ///报单类型
            cTPOrder.orderType = results[i++];
            ///今成交数量
            cTPOrder.volumeTraded = FCTran.strToInt(results[i++]);
            ///剩余数量
            cTPOrder.volumeTotal = FCTran.strToInt(results[i++]);
            ///报单日期
            cTPOrder.insertDate = results[i++];
            ///委托时间
            cTPOrder.insertTime = results[i++];
            ///激活时间
            cTPOrder.activeTime = results[i++];
            ///挂起时间
            cTPOrder.suspendTime = results[i++];
            ///最后修改时间
            cTPOrder.updateTime = results[i++];
            ///撤销时间
            cTPOrder.cancelTime = results[i++];
            ///最后修改交易所交易员代码
            cTPOrder.activeTraderID = results[i++];
            ///结算会员编号
            cTPOrder.clearingPartID = results[i++];
            ///序号
            cTPOrder.sequenceNo = FCTran.strToInt(results[i++]);
            ///前置编号
            cTPOrder.frontID = FCTran.strToInt(results[i++]);
            ///会话编号
            cTPOrder.sessionID = FCTran.strToInt(results[i++]);
            ///用户端产品信息
            cTPOrder.userProductInfo = results[i++];
            ///状态信息
            cTPOrder.statusMsg = results[i++];
            ///用户强评标志
            cTPOrder.userForceClose = FCTran.strToInt(results[i++]);
            ///操作用户代码
            cTPOrder.activeUserID = results[i++];
            ///经纪公司报单编号
            cTPOrder.brokerOrderSeq = FCTran.strToInt(results[i++]);
            ///相关报单
            cTPOrder.relativeOrderSysID = results[i++];
            ///郑商所成交数量
            cTPOrder.zCETotalTradedVolume = FCTran.strToInt(results[i++]);
            ///互换单标志
            cTPOrder.isSwapOrder = FCTran.strToInt(results[i++]);
            return cTPOrder;
        }

        /// <summary>
        /// 转换CTP交易信息
        /// </summary>
        /// <param name="result">字符串</param>
        /// <returns>CTP交易信息</returns>
        public static TradeRecord convertToCTPTrade(String result) {
            //CTP交易信息返回
            String[] results = result.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            TradeRecord cTPTrade = null;
            cTPTrade = new TradeRecord();
            int i = 0;
            ///经纪公司代码
            cTPTrade.brokerID = results[i++];
            ///投资者代码
            cTPTrade.investorID = results[i++];
            ///合约代码
            cTPTrade.code = results[i++];
            ///报单引用
            cTPTrade.orderRef = results[i++];
            ///用户代码
            cTPTrade.userID = results[i++];
            ///交易所代码
            cTPTrade.exchangeID = results[i++];
            ///成交编号
            cTPTrade.tradeID = results[i++];
            ///买卖方向
            cTPTrade.direction = results[i++];
            ///报单编号
            cTPTrade.orderSysID = results[i++];
            ///会员代码
            cTPTrade.participantID = results[i++];
            ///客户代码
            cTPTrade.clientID = results[i++];
            ///交易角色
            cTPTrade.tradingRole = results[i++];
            ///合约在交易所的代码
            cTPTrade.exchangeInstID = results[i++];
            ///开平标志
            cTPTrade.offsetFlag = results[i++];
            ///投机套保标志
            cTPTrade.hedgeFlag = results[i++];
            ///价格
            cTPTrade.price = FCTran.strToDouble(results[i++]);
            ///数量
            cTPTrade.volume = FCTran.strToInt(results[i++]);
            ///成交时期
            cTPTrade.tradeDate = results[i++];
            ///成交时间
            cTPTrade.tradeTime = results[i++];
            ///成交类型
            cTPTrade.tradeType = results[i++];
            ///成交价来源
            cTPTrade.priceSource = results[i++];
            ///交易所交易员代码
            cTPTrade.traderID = results[i++];
            ///本地报单编号
            cTPTrade.orderLocalID = results[i++];
            ///结算会员编号
            cTPTrade.clearingPartID = results[i++];
            ///业务单元
            cTPTrade.businessUnit = results[i++];
            ///序号
            cTPTrade.sequenceNo = FCTran.strToInt(results[i++]);
            ///交易日
            cTPTrade.tradingDay = results[i++];
            ///结算编号
            cTPTrade.settlementID = FCTran.strToInt(results[i++]);
            ///经纪公司报单编号
            cTPTrade.brokerOrderSeq = FCTran.strToInt(results[i++]);
            ///成交来源
            cTPTrade.tradeSource = results[i++];
            ///手续费
            cTPTrade.commission = FCTran.strToDouble(results[i++]);
            return cTPTrade;
        }

        /// <summary>
        /// 转换CTP交易信息列表
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static List<TradeRecord> convertToCTPTradeRecords(String result) {
            List<TradeRecord> list = new List<TradeRecord>();
            //报单信息返回
            String[] results = result.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < results.Length; i++) {
                TradeRecord trade = convertToCTPTrade(results[i]);
                if (trade != null) {
                    list.Add(trade);
                }
            }
            return list;
        }
    }
}
