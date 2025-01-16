/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2023/4/20 16:03:56                           */
/*==============================================================*/


drop table if exists sb_bank;

drop table if exists sb_bank_currency;

drop table if exists sb_bank_order;

drop table if exists sb_bank_paytype_channel;

drop table if exists sb_bank_spei_code;

drop table if exists sb_mongopay_bankcode;

drop table if exists sb_order_trans_log;

drop table if exists sb_panda_user_barcode;

drop table if exists sb_paytype;

drop table if exists sb_user_vanumber;

/*==============================================================*/
/* Table: sb_bank                                               */
/*==============================================================*/
create table sb_bank
(
   BankID               varchar(50) not null  comment '银行编码',
   BankName             varchar(50)  comment '银行名称',
   BankType             int not null default 0  comment '银行类型',
   TrdPublicKey         text  comment '第三方公钥',
   OwnPublicKey         text  comment '我方的公钥',
   OwnPrivateKey        text  comment '我方的私钥',
   Note                 varchar(1000)  comment '备注信息',
   Status               int not null default 0  comment '状态(0-无效1-有效)',
   RecDate              datetime not null default CURRENT_TIMESTAMP  comment '记录时间',
   primary key (BankID)
);

alter table sb_bank comment '银行表';

/*==============================================================*/
/* Table: sb_bank_currency                                      */
/*==============================================================*/
create table sb_bank_currency
(
   BankID               varchar(50) not null  comment '银行编码',
   CurrencyID           varchar(5) not null  comment '货币类型',
   primary key (BankID, CurrencyID)
);

/*==============================================================*/
/* Table: sb_bank_order                                         */
/*==============================================================*/
create table sb_bank_order
(
   OrderID              varchar(38) not null  comment '订单编码GUID',
   ProviderID           varchar(50)  comment '应用提供商编码',
   AppID                varchar(50)  comment '应用编码',
   OperatorID           varchar(50)  comment '运营商编码',
   UserID               varchar(38) not null  comment '用户编码(GUID)',
   UserKind             int not null default 0  comment '用户类型
             0-未知
             1-普通用户
             2-开发用户
             3-线上测试用户（调用第三方扣减）
             4-线上测试用户（不调用第三方扣减）
             5-仿真用户
             6-接口联调用户
             9-管理员',
   OrderType            int not null default 0  comment '充值返现1-充值2-返现',
   BankID               varchar(50)  comment '银行编码',
   PaytypeID            int not null default 0  comment '支付方式0-综合1-visa2-spei',
   PaytypeChannel       int not null default 0  comment '支付方式下的渠道',
   CurrencyID           varchar(5)  comment '货币类型（货币缩写USD）',
   RecDate              datetime not null default CURRENT_TIMESTAMP  comment '记录时间',
   PlanAmount           bigint not null default 0  comment '计划变化金额（正负数）',
   AppRequestUUID       varchar(38)  comment '请求唯一号',
   AppOrderId           varchar(38)  comment 'app订单编码',
   AppReqComment        varchar(255)  comment '请求备注',
   AppRequestTime       datetime not null default CURRENT_TIMESTAMP  comment '请求时间',
   AccName              varchar(50)  comment '账户名称',
   AccNumber            varchar(50)  comment '账户卡号',
   BankCode             varchar(20)  comment '银行编码',
   IsFirstCashOfDay     bool not null default 0  comment '是否当天第一次提现',
   Meta                 text  comment '扩展数据',
   Status               int not null default 0  comment '状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理',
   OwnOrderId           varchar(50)  comment '我方传给银行的订单号（transaction_id）对账使用!',
   BankResponseTime     datetime  comment '银行返回时间',
   BankOrderId          varchar(50)  comment '银行订单编码',
   BankCallbackTime     datetime  comment '银行回调时间',
   Amount               bigint not null default 0  comment '实际数量（正负数）',
   OwnFee               decimal(10,2) not null default 0  comment '我方承担的手续费',
   UserFee              decimal(10,2) not null default 0  comment '用户承担的手续费',
   UserMoney            decimal(10,2) not null default 0  comment '支付金额（提款金额）',
   EndBalance           bigint not null  comment '处理后余额',
   SettlTable           varchar(100)  comment '结算表名',
   SettlId              varchar(50)  comment '结算编码',
   SettlAmount          bigint not null default 0  comment '结算金额(正负数)',
   SettlStatus          int not null default 0  comment '结算状态（0-未结算1-已结算）',
   primary key (OrderID)
);

alter table sb_bank_order comment '银行订单表';

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create index Index_1 on sb_bank_order
(
   BankID,
   OwnOrderId
);

/*==============================================================*/
/* Index: Index_2                                               */
/*==============================================================*/
create index Index_2 on sb_bank_order
(
   AppOrderId,
   BankID
);

/*==============================================================*/
/* Index: Index_3                                               */
/*==============================================================*/
create index Index_3 on sb_bank_order
(
   BankID,
   BankOrderId
);

/*==============================================================*/
/* Index: Index_4                                               */
/*==============================================================*/
create index Index_4 on sb_bank_order
(
   BankCallbackTime,
   UserKind,
   Status
);

/*==============================================================*/
/* Table: sb_bank_paytype_channel                               */
/*==============================================================*/
create table sb_bank_paytype_channel
(
   BankID               varchar(50) not null  comment '银行编码',
   PaytypeID            int not null default 0  comment '支付方式0-综合1-visa2-spei',
   PaytypeChannel       int not null default 0  comment '支付方式下的渠道',
   ChannelName          varchar(50)  comment '渠道名称',
   primary key (BankID, PaytypeID, PaytypeChannel)
);

/*==============================================================*/
/* Table: sb_bank_spei_code                                     */
/*==============================================================*/
create table sb_bank_spei_code
(
   SpeiCode             varchar(20) not null  comment 'Spei支付用户标识',
   IsUsed               bool not null default 0  comment '是否使用',
   UseDate              datetime  comment '使用时间',
   UserID               varchar(38)  comment '用户编码(GUID)',
   primary key (SpeiCode)
);

alter table sb_bank_spei_code comment 'spei支付个人可用序号';

/*==============================================================*/
/* Index: Index_1                                               */
/*==============================================================*/
create index Index_1 on sb_bank_spei_code
(
   UserID
);

/*==============================================================*/
/* Table: sb_mongopay_bankcode                                  */
/*==============================================================*/
create table sb_mongopay_bankcode
(
   BankCode             varchar(50) not null  comment '银行代码',
   BankName             varchar(100)  comment '银行名称'
);

alter table sb_mongopay_bankcode comment 'mongopay所支持的银行列表';

/*==============================================================*/
/* Table: sb_order_trans_log                                    */
/*==============================================================*/
create table sb_order_trans_log
(
   TransLogID           varchar(38) not null  comment '请求应答日志编码(GUID)',
   OrderID              varchar(38) not null  comment '请求ID GUID',
   AppID                varchar(50)  comment '应用编码',
   BankID               varchar(50)  comment '银行编码',
   TransType            int not null default 0  comment '通讯类型(0-我方发起1-对方发起)',
   TransMark            varchar(255)  comment '通讯标记（接口标识）',
   RequestBody          text  comment '请求消息（我方请求或对方push）json',
   RequestTime          datetime not null default CURRENT_TIMESTAMP  comment '请求时间',
   ResponseTime         datetime  comment '返回时间',
   ResponseBody         text  comment '响应消息（对方响应或我方响应）json',
   Exception            text  comment '异常消息',
   Status               int not null default 0  comment '消息状态
             0-初始
             1-调用成功
             2-返回错误或调用异常，无需处理
             3-出现异常，需处理
             4-异常已处理',
   primary key (TransLogID)
);

alter table sb_order_trans_log comment '与app或bank调用方通讯日志(http)';

/*==============================================================*/
/* Table: sb_panda_user_barcode                                 */
/*==============================================================*/
create table sb_panda_user_barcode
(
   UserID               varchar(38) not null  comment '用户编码',
   BarCode              varchar(500)  comment '还款码',
   OwnOrderId           varchar(50)  comment '我方向对方请求的订单号',
   PlatOrderNum         varchar(50)  comment '对方订单号',
   AppID                varchar(50)  comment 'app编码',
   OperatorID           varchar(50)  comment '运营商编码',
   CurrencyID           varchar(50)  comment '货币编码',
   RecDate              datetime not null default 'current timestamp'  comment '时间记录',
   primary key (UserID)
);

alter table sb_panda_user_barcode comment 'panda支付表-用户barcode';

/*==============================================================*/
/* Table: sb_paytype                                            */
/*==============================================================*/
create table sb_paytype
(
   PaytypeID            int not null  comment '支付类型编码',
   Name                 varchar(20)  comment '支付类型',
   primary key (PaytypeID)
);

alter table sb_paytype comment '支付方式：visa，电子钱包，spei等';

/*==============================================================*/
/* Table: sb_user_vanumber                                      */
/*==============================================================*/
create table sb_user_vanumber
(
   UserID               varchar(38) not null  comment '用户编码(GUID)',
   VaNumber             varchar(50)  comment '虚拟账号',
   OrderID              varchar(50)  comment '我方订单号',
   PlatOrderNum         varchar(50)  comment '对方订单号（平台订单号）',
   AppID                varchar(50)  comment '应用编码',
   OperatorID           varchar(50)  comment '运营商编码',
   CurrencyID           varchar(5)  comment '货币类型',
   primary key (UserID)
);

alter table sb_user_vanumber comment '用户与虚拟账号对应关系';

