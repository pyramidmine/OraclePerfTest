﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OraclePerfTest.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("211.171.200.81")]
        public string ServerIp {
            get {
                return ((string)(this["ServerIp"]));
            }
            set {
                this["ServerIp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5521")]
        public string ServerPort {
            get {
                return ((string)(this["ServerPort"]));
            }
            set {
                this["ServerPort"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ALADIN")]
        public string DatabaseName {
            get {
                return ((string)(this["DatabaseName"]));
            }
            set {
                this["DatabaseName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MANNA")]
        public string DatabaseId {
            get {
                return ((string)(this["DatabaseId"]));
            }
            set {
                this["DatabaseId"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Ekswnr59")]
        public string DatabasePassword {
            get {
                return ((string)(this["DatabasePassword"]));
            }
            set {
                this["DatabasePassword"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal UserCount {
            get {
                return ((decimal)(this["UserCount"]));
            }
            set {
                this["UserCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1")]
        public string QueryRate {
            get {
                return ((string)(this["QueryRate"]));
            }
            set {
                this["QueryRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT /*+ LEADING(A) INDEX(A MN_A1_TODAY_IX_4) USE_NL(B) INDEX(B MN_A1_TODAY_ADD" +
            "_PK) NLJ_BATCHING */\r\n       A.ORD_NO ,\r\n       A.ORD_TODAY_NO,\r\n       A.ORD_TO" +
            "DAY_ADD_NO,\r\n       A.ORD_TODAY_ALL_NO,\r\n       A.ORD_TYPE_CD,\r\n       A.ORD_STA" +
            "TUS_CD ,\r\n       A.ORD_DATE,\r\n       A.MOD_DATE,\r\n       A.PICKUP_DATE,\r\n       " +
            "A.TAKEOUT_DATE,\r\n       A.END_DATE ,\r\n       A.ORD_CU_TEL,\r\n       A.ORD_CU_END_" +
            "CNT,\r\n       A.EA_ADDR_4,\r\n       A.DVRY_DISTANCE,\r\n       A.DVRY_AMT ,\r\n       " +
            "A.ORD_AMT,\r\n       A.DISCOUNT_AMT,\r\n       A.SRV_AMT,\r\n       A.CHARGE_TYPE,\r\n  " +
            "     A.PAY_TYPE_CD ,\r\n       A.PAY_AMT,\r\n       A.PAY_MILEAGE,\r\n       B.TRAN_TY" +
            "PE,\r\n       A.CTH_WK_NAME,\r\n       A.CTH_WK_TEL ,\r\n       A.ORD_MEMO,\r\n       B." +
            "CTH_ST_NAME,\r\n       A.DVRY_CNT,\r\n       A.ORD_PATH_CD,\r\n       B.CTH_ST_TEL ,\r\n" +
            "       B.ORD_CU_NAME,\r\n       A.TAKEOUT_YN,\r\n       A.ORD_ST_CODE,\r\n       A.ORD" +
            "_ST_NAME,\r\n       A.DVRY_TYPE_CD ,\r\n       A.XY_ACC_TYPE,\r\n       A.EA_ADDR_5,\r\n" +
            "       A.READY_TIME,\r\n       A.GOODS_NAMES,\r\n       A.ORG_PAY_TYPE ,\r\n       A.C" +
            "ASH_MOVE_CNT,\r\n       A.CASH_MOVE_AMT,\r\n       B.ORD_BR_CODE,\r\n       A.EA_ADDR_" +
            "6,\r\n       A.EA_ADDR_7 ,\r\n       A.PUT_USER_ID,\r\n       B.CTH_BR_CODE,\r\n       B" +
            ".CTH_ST_CODE,\r\n       A.CTH_WK_ARR_TIME,\r\n       A.CTH_DATE ,\r\n       A.READY_CH" +
            "ANGE_DATE,\r\n       A.CTH_DVRY_TYPE_CD,\r\n       A.DVRY_LOCK_TIME,\r\n       A.ST_DV" +
            "RY_TYPE_CD,\r\n       B.ORD_CU_MULTI_END_CNT ,\r\n       A.DVRY_EX_CHARGE,\r\n       A" +
            ".DVRY_MNG_TYPE,\r\n       A.DVRY_MNG_FEE,\r\n       B.VAN_TYPE_CD,\r\n       B.CARD_AP" +
            "PR_NUM ,\r\n       A.MOD_USER_ID,\r\n       B.ORD_MASTER_ST_CODE,\r\n       B.CTH_MNG_" +
            "BR_CODE,\r\n       B.CTH_MNG_HD_CODE,\r\n       B.ORD_HD_CODE ,\r\n       A.EA_ADDR_MO" +
            "D_CNT,\r\n       A.CTH_WK_ARR_DATE,\r\n       A.READY_CTH_YN,\r\n       A.CALL_ST_CODE" +
            ",\r\n       A.SA_LAT_Y ,\r\n       A.SA_LNG_X,\r\n       A.CANCEL_DATE,\r\n       A.SA_A" +
            "PP_ADDR,\r\n       A.POS_ORD_CODE,\r\n       B.EA_ADDR_10 ,\r\n       A.CTH_WK_CODE,\r\n" +
            "       B.ACQUIRER_NAME,\r\n       A.EA_LAT_Y,\r\n       A.EA_LNG_X,\r\n       B.ORD_BR" +
            "_NAME ,\r\n       A.CU_050_NUM ,\r\n       TO_CHAR(A.ORD_DATE, \'YYYYMMDDHH24MISS\') A" +
            "S CUSTOM_ORD_DATE ,\r\n       TO_CHAR(A.READY_CHANGE_DATE, \'YYYYMMDDHH24MISS\') AS " +
            "CUSTOM_READY_CHANGE_DATE ,\r\n       TO_CHAR(A.CTH_WK_ARR_DATE, \'YYYYMMDDHH24MISS\'" +
            ") AS CUSTOM_CTH_WK_ARR_DATE ,\r\n       TO_CHAR(A.PICKUP_DATE, \'YYYYMMDDHH24MISS\')" +
            " AS CUSTOM_PICKUP_DATE ,\r\n       TO_CHAR(A.END_DATE, \'YYYYMMDDHH24MISS\') AS CUST" +
            "OM_END_DATE ,\r\n       TO_CHAR(A.CANCEL_DATE, \'YYYYMMDDHH24MISS\') AS CUSTOM_CANCE" +
            "L_DATE ,\r\n       TO_CHAR(A.CTH_DATE, \'YYYYMMDDHH24MISS\') AS CUSTOM_CTH_DATE ,\r\n " +
            "      TO_CHAR(A.MOD_DATE, \'YYYYMMDDHH24MISS\') AS CUSTOM_MOD_DATE ,\r\n       TO_CH" +
            "AR(A.MOD_DATE, \'YYYYMMDDHH24MISSFF3\') AS CUSTOM_MOD_DATE_FF3 ,\r\n       TRUNC(A.D" +
            "VRY_DISTANCE / 1000, 1) AS CUSTOM_DVRY_DISTANCE ,\r\n       B.EA_ADDR_STR ,\r\n     " +
            "  A.ORG_ORD_NO,\r\n       A.ORG_ORD_PATH_CD ,\r\n       B.VAN_TYPE_STR AS ARR_VAN_TY" +
            "PE_CD ,\r\n       TO_CHAR(A.PUT_DATE, \'YYYYMMDDHH24MISS\') AS CUSTOM_PUT_DATE,\r\n   " +
            "    A.ORD_DATA_YN ,\r\n       A.DVRY_TAX_YN,\r\n       A.DVRY_NLT_TYPE,\r\n       B.ST" +
            "_DVRY_HD_CODE,\r\n       B.ST_DVRY_BR_CODE,\r\n       A.CHARGE_HISTORY ,\r\n       A.A" +
            "RR_TIME,\r\n       A.DVRY_GRP_TYPE,\r\n       A.ORD_ST_TEL,\r\n       A.PRE_CTH_YN,\r\n " +
            "      A.CTH_WK_GOODS_PAY_TYPE ,\r\n       A.MOD_SEQ_NO,\r\n       A.EXT_ORD_NO\r\n  FR" +
            "OM MN_A1_TODAY A,\r\n       MN_A1_TODAY_ADD B\r\n WHERE A.ORD_NO = B.ORD_NO\r\n   AND " +
            "A.ORD_DATA_YN = \'Y\'\r\n   AND A.MOD_DATE >= sysdate-$1/(24*60*60)")]
        public string Query {
            get {
                return ((string)(this["Query"]));
            }
            set {
                this["Query"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("70")]
        public string QueryArguments {
            get {
                return ((string)(this["QueryArguments"]));
            }
            set {
                this["QueryArguments"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1")]
        public string OpenRate {
            get {
                return ((string)(this["OpenRate"]));
            }
            set {
                this["OpenRate"] = value;
            }
        }
    }
}
