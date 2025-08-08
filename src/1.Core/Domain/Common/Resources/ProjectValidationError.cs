namespace TranslationProvider.Core.Domain.Common.Resources;

public abstract class ProjectValidationError
{
    #region Entity
    //الگو : مقدار {0} معتبر نمی باشد
    //مثال : مقدار "ریحون" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);

    //الگو : مقدار {0} اجباری می باشد
    //مثال : مقدار "عنوان" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED = nameof(VALIDATION_ERROR_REQUIRED);

    //الگو : {0} وجود دارد
    //مثال : "میوه" وجود دارد
    public const string VALIDATION_ERROR_EXIST = nameof(VALIDATION_ERROR_EXIST);

    //الگو : {0} وجود ندارد
    //مثال : "میوه" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);

    //الگو : تغییر {0} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "میوه" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_USED_ITEM = nameof(VALIDATION_ERROR_MODIFY_USED_ITEM);

    //الگو : حذف {0} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : حذف "میوه" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_DELETE_USED_ITEM = nameof(VALIDATION_ERROR_DELETE_USED_ITEM);

    //الگو : تغییر {0} به دلیل محافظت شده بودن آن امکان پذیر نیست
    //مثال : تغییر "میوه" به دلیل محافظت شده بودن آن امکان پذیر نیست
    public const string VALIDATION_ERROR_MODIFY_PROTECTED_ITEM = nameof(VALIDATION_ERROR_MODIFY_PROTECTED_ITEM);

    //الگو : حذف {0} به دلیل محافظت شده بودن آن امکان پذیر نیست
    //مثال : حذف "میوه" به دلیل محافظت شده بودن آن امکان پذیر نیست
    public const string VALIDATION_ERROR_DELETE_PROTECTED_ITEM = nameof(VALIDATION_ERROR_DELETE_PROTECTED_ITEM);

    //الگو : تغییر وضعیت {0} از {1} به {2} امکان پذیر نمی باشد
    //مثال : تغییر وضعیت "میوه" از "شیرین" به "ترش" امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_CHANGE_STATUS = nameof(VALIDATION_ERROR_CHANGE_STATUS);
    #endregion

    #region Entity Value
    //الگو : مقدار {0} برای {1} در {2} معتبر نمی باشد
    //مثال : مقدار "ریحون" برای "عنوان" در "میوه" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID_VALUE = nameof(VALIDATION_ERROR_NOT_VALID_VALUE);

    //الگو : مقدار {0} در {1} اجباری می باشد
    //مثال : مقدار "عنوان" در "میوه" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED_VALUE = nameof(VALIDATION_ERROR_REQUIRED_VALUE);

    //الگو : {0} با {1} {2} وجود دارد
    //مثال : "میوه" با "عنوان" "سیب" وجود دارد
    public const string VALIDATION_ERROR_EXIST_WITH_VALUE = nameof(VALIDATION_ERROR_EXIST_WITH_VALUE);

    //الگو : {0} با {1} {2} وجود ندارد
    //مثال : "میوه" با "عنوان" "ریحون" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_WITH_VALUE = nameof(VALIDATION_ERROR_NOT_EXIST_WITH_VALUE);

    //الگو : مقدار {0} برای {1} در {2} تکراری می باشد
    //مثال : مقدار "سیب" برای "عنوان" در "میوه" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE_VALUE = nameof(VALIDATION_ERROR_DUPLICATE_VALUE);

    //الگو : تغییر {0} برای {1} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر نام برای "میوه" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM);

    //الگو : تغییر {0} برای {1} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر نام برای "میوه" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM);
    #endregion

    #region Subset
    //الگو : {0} در {1} {2} معتبر نمی باشد
    //مثال : "زمین" در "سیاره های" "مظومه شمسی" معتبر نمی باشد
    public const string VALIDATION__NOT_VALID_IN_SUBSET = nameof(VALIDATION__NOT_VALID_IN_SUBSET);

    //الگو : {0} در {1} {2} وجود دارد
    //مثال : "زمین" در "سیاره های" "مظومه شمسی" وجود دارد
    public const string VALIDATION_ERROR_EXIST_IN_SUBSET = nameof(VALIDATION_ERROR_EXIST_IN_SUBSET);

    //الگو : {0} در {1} {2} دارد
    //مثال : "سیب" در"سیاره های" "مظومه شمسی" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_EXIST_IN_SUBSET);
    #endregion

    #region Subset Value
    //الگو : مقدار {0} برای {1} در {2} ، برای {3} {4} معتبر نمی باشد
    //مثال : مقدار "سیب" برای "عنوان" در "قاره" ، برای "قاره های" "زمین" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_VALID_VALUE_IN_SUBSET);

    //الگو : مقدار {0} در {1} ، برای {2} {3} اجباری می باشد
    //مثال : مقدار "عنوان" در "قاره" ، برای "قاره های" "زمین" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_REQUIRED_VALUE_IN_SUBSET);

    //الگو : {0} با {1} {2} در {3} {4} وجود دارد
    //مثال : "قاره" با "عنوان" "آسیا" در "قاره های" "زمین" وجود دارد
    public const string VALIDATION_ERROR_EXIST_WITH_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_EXIST_WITH_VALUE);

    //الگو : {0} با {1} {2} در {3} {4} وجود ندارد
    //مثال : "قاره" با "عنوان" "سیب" در "قاره های" "زمین" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_WITH_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_EXIST_WITH_VALUE);

    //الگو : مقدار {0} برای {1} در {2} ، برای {3} {4} تکراری می باشد
    //مثال : مقدار "سیب" برای "عنوان" در "قاره" ، برای "قاره های" "زمین" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_DUPLICATE_VALUE_IN_SUBSET);
    #endregion

    #region String
    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);

    public const string VALIDATION_ERROR_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH);

    public const string VALIDATION_ERROR_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH);

    public const string VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL = nameof(VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL);

    public const string VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE);

    public const string VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE);

    public const string VALIDATION_ERROR_STRING_MUST_HAS_DIGIT = nameof(VALIDATION_ERROR_STRING_MUST_HAS_DIGIT);

    public const string VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC = nameof(VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC);

    public const string VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR);

    //طول مناسب {0} برای {1} در {2}ِ در {3} کوچک تر برابر {4} می باشد
    //مثال : طول مناسب "کد" برای "کشور" در "کشورها" در "سیاره" کوچک تر برابر "2" می باشد 
    public const string VALIDATION_ERROR_STRING_LENGTH_FOR_IN_SUBSET = nameof(VALIDATION_ERROR_STRING_LENGTH_FOR_IN_SUBSET);
    #endregion

    #region Number
    public const string VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO = nameof(VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO);

    public const string VALIDATION_ERROR_NUMBER_BETWEEN = nameof(VALIDATION_ERROR_NUMBER_BETWEEN);

    public const string VALIDATION_ERROR_NUMBER_LESS_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN);

    public const string VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN);

    public const string VALIDATION_ERROR_NUMBER_GRATER_THAN = nameof(VALIDATION_ERROR_NUMBER_GRATER_THAN);

    public const string VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_GRATER_OR_EQUAL_THAN);
    #endregion

    #region Date
    public const string VALIDATION_ERROR_DATE_LESS_THAN = nameof(VALIDATION_ERROR_DATE_LESS_THAN);

    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL);

    public const string VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY);

    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY);

    public const string VALIDATION_ERROR_DATE_GREATER_THAN = nameof(VALIDATION_ERROR_DATE_GREATER_THAN);

    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL);

    public const string VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY);

    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY);
    #endregion
}