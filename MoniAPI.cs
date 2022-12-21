using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;

namespace ctpcs
{
    /// <summary>
    /// ģ�⽻��API
    /// </summary>
    public class MoniAPI
    {
        /*
         * ����Http
         * url��ַ
         */
        public static String callAPI(String url)
        {
            return FCHttpGetService.get("http://127.0.0.1:9962?facecatid=app_SimTrading&" + url);
        }

        /*׷���ʽ�
        accountid �˻�ID
        cash �ʽ�*/
        public static String addFund(String accountid, double cash)
        {
            return callAPI("func=addfund&accountid=" + accountid + "&cash=" + FCTran.doubleToStr(cash));
        }

        /*���ί��
        accountid �˻�ID
        code ����
        name ����
        ordertype ί������
        direction ����
        price �۸�
        volume ����
        margin ��֤��
        ���� ί��ID*/
        public static String addOrder(String accountid, String code, String name, String ordertype, String direction, double price, double volume, double margin)
        {
            return callAPI("func=addorder&accountid=" + accountid + "&code=" + code + "&name=" + name + "&ordertype=" + ordertype + "&direction=" + direction + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&margin=" + FCTran.doubleToStr(margin));
        }

        /*��ӳɽ�
        accountid �˻�ID
        code ����
        name ����
        ordertype ί������
        orderid ί��ID
        direction ����
        price �۸�
        volume ����
        amount ����
        commision #������
        ���� �ɽ�ID*/
        public static String addTrade(String accountid, String code, String name, String ordertype, String orderid, String direction, double price, double volume, double amount, double commision)
        {
            return callAPI("func=addtrade&accountid=" + accountid + "&code=" + code + "&name=" + name + "&ordertype=" + ordertype + "&orderid=" + "&direction=" + direction + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&amount=" + FCTran.doubleToStr(amount) + "&commision=" + FCTran.doubleToStr(commision));
        }

        /*��ӳֲ�
        accountid �˻�ID
        code ����
        name ����
        price �۸�
        volume ����
        direction ����
        margin ��֤��
        commision ������*/
        public static String addPosition(String accountid, String code, String name, double price, double volume, String direction, double margin, double commision)
        {
            return callAPI("func=addposition&accountid=" + accountid + "&code=" + code + "&name=" + name + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&direction=" + direction + "&margin=" + FCTran.doubleToStr(margin) + "&commision=20" + FCTran.doubleToStr(commision));
        }

        /*���뽻��
        accountid �˻�ID
        code ����
        name ����
        price ����
        volume ����
        direction ����
        margin ��֤��
        commision ������*/
        public static String buy(String accountid, String code, String name, String ordertype, String direction, double price, double volume, double amount, double margin, double commision)
        {
            return callAPI("func=buy&accountid=" + accountid + "&code=" + code + "&name=" + name + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&ordertype=" + ordertype + "&direction=" + direction + "&margin=" + FCTran.doubleToStr(margin) + "&commision=" + FCTran.doubleToStr(commision));
        }

        /*�����˻�*/
        public static String createAccount()
        {
            return callAPI("func=createaccount");
        }

        /*��ǰ�˻�*/
        public static String getCurrentAccount()
        {
            return callAPI("func=getcurrentaccount");
        }

        /*ָ���˻�
        accountid �˻�ID*/
        public static String getFund(String accountid)
        {
            return callAPI("func=getfund&accountid=" + accountid);
        }

        /*�����˻�*/
        public static String getAllFunds()
        {
            return callAPI("func=getallfunds");
        }

        /*�ֲ��б�
        accountid �˻�ID*/
        public static String getPositionsByAccount(String accountid)
        {
            return callAPI("func=getpositionsbyaccount&accountid=" + accountid);
        }

        /*�µ�ί��
        accountid �˻�ID*/
        public static String getNewOrders(String accountid)
        {
            return callAPI("func=getnewtrades&accountid=" + accountid);
        }

        /*�µĳֲ�
        accountid �˻�ID*/
        public static String getNewPositions(String accountid)
        {
            return callAPI("func=getnewpositions&accountid=" + accountid);
        }

        /*�µĳɽ�
        accountid �˻�ID*/
        public static String getNewTrades(String accountid)
        {
            return callAPI("func=getnewtrades&accountid=" + accountid);
        }

        /*ί���б�
        accountid �˻�ID*/
        public static String getOrdersByAccount(String accountid)
        {
            return callAPI("func=getordersbyaccount&accountid=" + accountid);
        }

        /*�ɽ��б�
        accountid �˻�ID*/
        public static String getTradesByAccount(String accountid)
        {
            return callAPI("func=gettradesbyaccount&accountid=" + accountid);
        }

        /*��������
        accountid �˻�ID*/
        public static String lockUI(String accountid)
        {
            return callAPI("func=lockui&accountid=" + accountid);
        }

        /*�Ƴ��˻�
        accountid �˻�ID*/
        public static String removeAccount(String accountid)
        {
            return callAPI("func=removeaccount&accountid=" + accountid);
        }

        /*ɾ���ɽ�
        accountid �˻�ID
        tradeid �ɽ�ID*/
        public static String removeTrade(String accountid, String tradeid)
        {
            return callAPI("func=removetrade&accountid=" + accountid + "&tradeid=" + tradeid);
        }

        /*����ί��
        accountid �˻�ID
        orderid ί��ID*/
        public static String removeOrder(String accountid, String orderid)
        {
            return callAPI("func=removeorder&accountid=" + accountid + "&orderid=" + orderid);
        }

        /*���ٳֲ�
        accountid �˻�ID
        code ����
        name ����
        price �۸�
        volume ����
        direction ����
        margin ��֤��
        commision ������*/
        public static String reducePosition(String accountid, String code, String name, double price, double volume, String direction, double margin, double commision)
        {
            return callAPI("func=reduceposition&accountid=" + accountid + "&code=" + code + "&name=" + name + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&direction=" + direction + "&margin=" + FCTran.doubleToStr(margin) + "&commision=20" + FCTran.doubleToStr(commision));
        }

        /*��������
        accountid �˻�ID
        code ����
        name ����
        price ����
        volume ����
        direction ����
        margin ��֤��
        commision ������*/
        public static String sell(String accountid, String code, String name, String ordertype, String direction, double price, double volume, double amount, double margin, double commision)
        {
            return callAPI("func=sell&accountid=" + accountid + "&code=" + code + "&name=" + name + "&price=" + FCTran.doubleToStr(price) + "&volume=" + FCTran.doubleToStr(volume) + "&ordertype=" + ordertype + "&direction=" + direction + "&margin=" + FCTran.doubleToStr(margin) + "&commision=" + FCTran.doubleToStr(commision));
        }

        /*���¼۸�
        accountid �˻�ID
        code ����
        direction #����
        marketprice #�м�
        marketvalue #��ֵ
         */
        public static String setMarketValue(String accountid, String code, String direction, double marketprice, double marketvalue)
        {
            return callAPI("func=setmarketvalue&accountid=" + accountid + "&code=" + code + "&direction=" + direction + "&marketprice=" + FCTran.doubleToStr(marketprice) + "&marketvalue=" + FCTran.doubleToStr(marketvalue));
        }

        /*��������
        accountid �˻�ID*/
        public static String unLockUI(String accountid)
        {
            return callAPI("func=unlockui&accountid=" + accountid);
        }
    }
}
