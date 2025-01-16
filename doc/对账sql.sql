
#pandapay
select DATE_ADD(BankCallbackTime, INTERVAL -3 HOUR) as '银行回调巴西时间', bankid as '合作银行',orderid as '我方订单编号',OwnOrderId as '我方传给三方的订单号',BankOrderId as '银行订单编号',case OrderType when 1 then '应收' when 2 then '应付' end  as '交易类型',CurrencyID as '货币类型',amount/10000.0 as '金额',ownfee as '我方承担手续费',userfee as '用户承担手续费'
from sb_bank_order where status=2 and ordertype=1 and bankid='pandapay' and BankCallbackTime<'2023-08-01 03:00:00' order by BankCallbackTime asc;

select DATE_ADD(BankCallbackTime, INTERVAL -3 HOUR) as '银行回调巴西时间', bankid as '合作银行',orderid as '我方订单编号',OwnOrderId as '我方传给三方的订单号',BankOrderId as '银行订单编号',case OrderType when 1 then '应收' when 2 then '应付' end  as '交易类型',CurrencyID as '货币类型',amount/10000.0 as '金额',ownfee as '我方承担手续费',userfee as '用户承担手续费'
from sb_bank_order where status=2 and ordertype=2 and bankid='pandapay' and BankCallbackTime<'2023-08-01 03:00:00' order by BankCallbackTime asc;


#tejeepay
select DATE_ADD(BankCallbackTime, INTERVAL -3 HOUR) as '银行回调巴西时间', bankid as '合作银行',orderid as '我方订单编号',OwnOrderId as '我方传给三方的订单号',BankOrderId as '银行订单编号',case OrderType when 1 then '应收' when 2 then '应付' end  as '交易类型',CurrencyID as '货币类型',amount/10000.0 as '金额',ownfee as '我方承担手续费',userfee as '用户承担手续费'
from sb_bank_order where status=2 and ordertype=1 and bankid='tejeepay' and BankCallbackTime<'2023-08-01 03:00:00' order by BankCallbackTime asc;

select DATE_ADD(BankCallbackTime, INTERVAL -3 HOUR) as '银行回调巴西时间', bankid as '合作银行',orderid as '我方订单编号',OwnOrderId as '我方传给三方的订单号',BankOrderId as '银行订单编号',case OrderType when 1 then '应收' when 2 then '应付' end  as '交易类型',CurrencyID as '货币类型',amount/10000.0 as '金额',ownfee as '我方承担手续费',userfee as '用户承担手续费'
from sb_bank_order where status=2 and ordertype=2 and bankid='tejeepay' and BankCallbackTime<'2023-08-01 03:00:00' order by BankCallbackTime asc;



