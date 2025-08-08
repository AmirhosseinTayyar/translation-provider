namespace TranslationProvider.Core.Domain.Common.Resources;

public abstract class ProjectValidationError
{
    #region Basic Validations
    //Pattern: {0} is not valid
    //Example: "Planet" is not valid
    //الگو : {0} معتبر نمی باشد
    //مثال : "سیاره" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);

    //Pattern: {0} is required
    //Example: "Planet name" is required
    //الگو : {0} اجباری می باشد
    //مثال : "سیاره" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED = nameof(VALIDATION_ERROR_REQUIRED);

    //Pattern: {0} exists
    //Example: "Mars" exists
    //الگو : {0} وجود دارد
    //مثال : "مریخ" وجود دارد
    public const string VALIDATION_ERROR_EXIST = nameof(VALIDATION_ERROR_EXIST);

    //Pattern: {0} does not exist
    //Example: "Pluto" does not exist
    //الگو : {0} وجود ندارد
    //مثال : "پلوتو" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);

    //Pattern: {0} is duplicate
    //Example: "Earth" is duplicate
    //الگو : {0} تکراری می باشد
    //مثال : "زمین" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE = nameof(VALIDATION_ERROR_DUPLICATE);

    //Pattern: Changing {0} is not possible due to it being in use
    //Example: Changing "Solar System" is not possible due to it being in use
    //الگو : تغییر {0} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "منظومه شمسی" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_USED_ITEM = nameof(VALIDATION_ERROR_MODIFY_USED_ITEM);

    //Pattern: Deleting {0} is not possible due to it being in use
    //Example: Deleting "Sun" is not possible due to it being in use
    //الگو : حذف {0} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : حذف "خورشید" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_DELETE_USED_ITEM = nameof(VALIDATION_ERROR_DELETE_USED_ITEM);

    //Pattern: Changing {0} is not possible due to it being protected
    //Example: Changing "Earth" is not possible due to it being protected
    //الگو : تغییر {0} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "زمین" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_PROTECTED_ITEM = nameof(VALIDATION_ERROR_MODIFY_PROTECTED_ITEM);

    //Pattern: Deleting {0} is not possible due to it being protected
    //Example: Deleting "Mercury" is not possible due to it being protected
    //الگو : حذف {0} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : حذف "عطارد" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_DELETE_PROTECTED_ITEM = nameof(VALIDATION_ERROR_DELETE_PROTECTED_ITEM);

    //Pattern: Changing status of {0} from {1} to {2} is not possible
    //Example: Changing status of "Venus" from "Active" to "Inactive" is not possible
    //الگو : تغییر وضعیت {0} از {1} به {2} امکان پذیر نمی باشد
    //مثال : تغییر وضعیت "زهره" از "فعال" به "غیرفعال" امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_CHANGE_STATUS = nameof(VALIDATION_ERROR_CHANGE_STATUS);
    #endregion

    #region Detailed Validations
    //Pattern: Value {0} for {1} in {2} is not valid
    //Example: Value "Purple" for "Color" in "Planet" is not valid
    //الگو : مقدار {0} برای {1} در {2} معتبر نمی باشد
    //مثال : مقدار "بنفش" برای "رنگ" در "سیاره" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID_VALUE = nameof(VALIDATION_ERROR_NOT_VALID_VALUE);

    //Pattern: Value {0} in {1} is required
    //Example: Value "Name" in "Country" is required
    //الگو : مقدار {0} در {1} اجباری می باشد
    //مثال : مقدار "نام" در "کشور" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED_VALUE = nameof(VALIDATION_ERROR_REQUIRED_VALUE);

    //Pattern: {0} with {1} {2} exists
    //Example: "Country" with "Name" "Germany" exists
    //الگو : {0} با {1} {2} وجود دارد
    //مثال : "کشور" با "نام" "ایران" وجود دارد
    public const string VALIDATION_ERROR_EXIST_WITH_VALUE = nameof(VALIDATION_ERROR_EXIST_WITH_VALUE);

    //Pattern: {0} with {1} {2} does not exist
    //Example: "Planet" with "Name" "Atlantis" does not exist
    //الگو : {0} با {1} {2} وجود ندارد
    //مثال : "سیاره" با "نام" "آتلانتیس" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_WITH_VALUE = nameof(VALIDATION_ERROR_NOT_EXIST_WITH_VALUE);

    //Pattern: Value {0} for {1} in {2} is duplicate
    //Example: Value "Earth" for "Name" in "Planet" is duplicate
    //الگو : مقدار {0} برای {1} در {2} تکراری می باشد
    //مثال : مقدار "زمین" برای "نام" در "سیاره" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE_VALUE = nameof(VALIDATION_ERROR_DUPLICATE_VALUE);

    //Pattern: Changing {0} for {1} is not possible due to it being in use
    //Example: Changing "Capital" for "Country" is not possible due to it being in use
    //الگو : تغییر {0} برای {1} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "پایتخت" برای "کشور" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM);

    //Pattern: Changing {0} for {1} is not possible due to it being protected
    //Example: Changing "Orbit" for "Planet" is not possible due to it being protected
    //الگو : تغییر {0} برای {1} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "مدار" برای "سیاره" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM);
    #endregion

    #region Collection Basic Validations
    //Pattern: {0} in {1} {2} is not valid
    //Example: "Jupiter" in "Planets of" "Solar System" is not valid
    //الگو : {0} در {1} {2} معتبر نمی باشد
    //مثال : "مشتری" در "سیارات" "منظومه شمسی" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_VALID_IN_SUBSET);

    //Pattern: {0} in {1} {2} is required
    //Example: "Earth" in "Planets of" "Solar System" is required
    //الگو : {0} در {1} {2} اجباری می باشد
    //مثال : "زمین" در "سیارات" "منظومه شمسی" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED_IN_SUBSET = nameof(VALIDATION_ERROR_REQUIRED_IN_SUBSET);

    //Pattern: {0} in {1} {2} exists
    //Example: "France" in "Countries of" "Europe" exists
    //الگو : {0} در {1} {2} وجود دارد
    //مثال : "فرانسه" در "کشورهای" "اروپا" وجود دارد
    public const string VALIDATION_ERROR_EXIST_IN_SUBSET = nameof(VALIDATION_ERROR_EXIST_IN_SUBSET);

    //Pattern: {0} in {1} {2} does not exist
    //Example: "Wakanda" in "Countries of" "Africa" does not exist
    //الگو : {0} در {1} {2} وجود ندارد
    //مثال : "واکاندا" در "کشورهای" "آفریقا" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_EXIST_IN_SUBSET);

    //Pattern: {0} in {1} {2} is duplicate
    //Example: "Mars" in "Planets of" "Solar System" is duplicate
    //الگو : {0} در {1} {2} تکراری می باشد
    //مثال : "مریخ" در "سیارات" "منظومه شمسی" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE_IN_SUBSET = nameof(VALIDATION_ERROR_DUPLICATE_IN_SUBSET);

    //Pattern: Changing {0} in {1} {2} is not possible due to it being in use
    //Example: Changing "Venus" in "Planets of" "Solar System" is not possible due to it being in use
    //الگو : تغییر {0} در {1} {2} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "زهره" در "سیارات" "منظومه شمسی" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_USED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_MODIFY_USED_ITEM_IN_SUBSET);

    //Pattern: Deleting {0} in {1} {2} is not possible due to it being in use
    //Example: Deleting "Germany" in "Countries of" "Europe" is not possible due to it being in use
    //الگو : حذف {0} در {1} {2} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : حذف "آلمان" در "کشورهای" "اروپا" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_DELETE_USED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_DELETE_USED_ITEM_IN_SUBSET);

    //Pattern: Changing {0} in {1} {2} is not possible due to it being protected
    //Example: Changing "Mercury" in "Planets of" "Solar System" is not possible due to it being protected
    //الگو : تغییر {0} در {1} {2} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "عطارد" در "سیارات" "منظومه شمسی" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_PROTECTED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_MODIFY_PROTECTED_ITEM_IN_SUBSET);

    //Pattern: Deleting {0} in {1} {2} is not possible due to it being protected
    //Example: Deleting "Italy" in "Countries of" "Europe" is not possible due to it being protected
    //الگو : حذف {0} در {1} {2} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : حذف "ایتالیا" در "کشورهای" "اروپا" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_DELETE_PROTECTED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_DELETE_PROTECTED_ITEM_IN_SUBSET);

    //Pattern: Changing status of {0} from {1} to {2} in {3} {4} is not possible
    //Example: Changing status of "Saturn" from "Visible" to "Hidden" in "Planets of" "Solar System" is not possible
    //الگو : تغییر وضعیت {0} از {1} به {2} در {3} {4} امکان پذیر نمی باشد
    //مثال : تغییر وضعیت "زحل" از "قابل مشاهده" به "مخفی" در "سیارات" "منظومه شمسی" امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_CHANGE_STATUS_IN_SUBSET = nameof(VALIDATION_ERROR_CHANGE_STATUS_IN_SUBSET);
    #endregion

    #region Collection Detailed Validations
    //Pattern: Value {0} for {1} in {2}, for {3} {4} is not valid
    //Example: Value "Purple" for "Color" in "Planet", for "Planets of" "Solar System" is not valid
    //الگو : مقدار {0} برای {1} در {2} ، برای {3} {4} معتبر نمی باشد
    //مثال : مقدار "بنفش" برای "رنگ" در "سیاره" ، برای "سیارات" "منظومه شمسی" معتبر نمی باشد
    public const string VALIDATION_ERROR_NOT_VALID_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_VALID_VALUE_IN_SUBSET);

    //Pattern: Value {0} in {1}, for {2} {3} is required
    //Example: Value "Capital" in "Country", for "Countries of" "Europe" is required
    //الگو : مقدار {0} در {1} ، برای {2} {3} اجباری می باشد
    //مثال : مقدار "پایتخت" در "کشور" ، برای "کشورهای" "اروپا" اجباری می باشد
    public const string VALIDATION_ERROR_REQUIRED_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_REQUIRED_VALUE_IN_SUBSET);

    //Pattern: {0} with {1} {2} in {3} {4} exists
    //Example: "Country" with "Name" "Spain" in "Countries of" "Europe" exists
    //الگو : {0} با {1} {2} در {3} {4} وجود دارد
    //مثال : "کشور" با "نام" "اسپانیا" در "کشورهای" "اروپا" وجود دارد
    public const string VALIDATION_ERROR_EXIST_WITH_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_EXIST_WITH_VALUE_IN_SUBSET);

    //Pattern: {0} with {1} {2} in {3} {4} does not exist
    //Example: "Planet" with "Name" "Krypton" in "Planets of" "Solar System" does not exist
    //الگو : {0} با {1} {2} در {3} {4} وجود ندارد
    //مثال : "سیاره" با "نام" "کریپتون" در "سیارات" "منظومه شمسی" وجود ندارد
    public const string VALIDATION_ERROR_NOT_EXIST_WITH_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_NOT_EXIST_WITH_VALUE_IN_SUBSET);

    //Pattern: Value {0} for {1} in {2}, for {3} {4} is duplicate
    //Example: Value "Earth" for "Name" in "Planet", for "Planets of" "Solar System" is duplicate
    //الگو : مقدار {0} برای {1} در {2} ، برای {3} {4} تکراری می باشد
    //مثال : مقدار "زمین" برای "نام" در "سیاره" ، برای "سیارات" "منظومه شمسی" تکراری می باشد
    public const string VALIDATION_ERROR_DUPLICATE_VALUE_IN_SUBSET = nameof(VALIDATION_ERROR_DUPLICATE_VALUE_IN_SUBSET);

    //Pattern: Changing {0} for {1} in {2} {3} is not possible due to it being in use
    //Example: Changing "Orbit" for "Planet" in "Planets of" "Solar System" is not possible due to it being in use
    //الگو : تغییر {0} برای {1} در {2} {3} به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "مدار" برای "سیاره" در "سیارات" "منظومه شمسی" به دلیل استفاده شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_USED_ITEM_IN_SUBSET);

    //Pattern: Changing {0} for {1} in {2} {3} is not possible due to it being protected
    //Example: Changing "Capital" for "Country" in "Countries of" "Europe" is not possible due to it being protected
    //الگو : تغییر {0} برای {1} در {2} {3} به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    //مثال : تغییر "پایتخت" برای "کشور" در "کشورهای" "اروپا" به دلیل محافظت شده بودن آن امکان پذیر نمی باشد
    public const string VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM_IN_SUBSET = nameof(VALIDATION_ERROR_MODIFY_VALUE_OF_PROTECTED_ITEM_IN_SUBSET);
    #endregion

    #region String Validations
    //Pattern: Length of {0} should be between {1} and {2} characters
    //Example: Length of "Planet Name" should be between "2" and "50" characters
    //الگو : طول {0} باید بین {1} و {2} کاراکتر باشد
    //مثال : طول "نام سیاره" باید بین "2" و "50" کاراکتر باشد
    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);

    //Pattern: Minimum length of {0} should be {1} characters
    //Example: Minimum length of "Country Code" should be "2" characters
    //الگو : حداقل طول {0} باید {1} کاراکتر باشد
    //مثال : حداقل طول "کد کشور" باید "2" کاراکتر باشد
    public const string VALIDATION_ERROR_STRING_MIN_LENGTH = nameof(VALIDATION_ERROR_STRING_MIN_LENGTH);

    //Pattern: Maximum length of {0} should be {1} characters
    //Example: Maximum length of "Galaxy Name" should be "100" characters
    //الگو : حداکثر طول {0} باید {1} کاراکتر باشد
    //مثال : حداکثر طول "نام کهکشان" باید "100" کاراکتر باشد
    public const string VALIDATION_ERROR_STRING_MAX_LENGTH = nameof(VALIDATION_ERROR_STRING_MAX_LENGTH);

    //Pattern: Length of {0} should be exactly {1} characters
    //Example: Length of "ISO Country Code" should be exactly "3" characters
    //الگو : طول {0} باید دقیقاً {1} کاراکتر باشد
    //مثال : طول "کد ایزو کشور" باید دقیقاً "3" کاراکتر باشد
    public const string VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL = nameof(VALIDATION_ERROR_STRING_LENGTH_MUST_EQUAL);

    //Pattern: {0} must contain at least one uppercase letter
    //Example: "Cosmic Password" must contain at least one uppercase letter
    //الگو : {0} باید حداقل یک حرف بزرگ داشته باشد
    //مثال : "رمز عبور کیهانی" باید حداقل یک حرف بزرگ داشته باشد
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UPPER_CASE);

    //Pattern: {0} must contain at least one lowercase letter
    //Example: "Star Name" must contain at least one lowercase letter
    //الگو : {0} باید حداقل یک حرف کوچک داشته باشد
    //مثال : "نام ستاره" باید حداقل یک حرف کوچک داشته باشد
    public const string VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE = nameof(VALIDATION_ERROR_STRING_MUST_HAS_LOWER_CASE);

    //Pattern: {0} must contain at least one digit
    //Example: "Planet Code" must contain at least one digit
    //الگو : {0} باید حداقل یک عدد داشته باشد
    //مثال : "کد سیاره" باید حداقل یک عدد داشته باشد
    public const string VALIDATION_ERROR_STRING_MUST_HAS_DIGIT = nameof(VALIDATION_ERROR_STRING_MUST_HAS_DIGIT);

    //Pattern: {0} must contain at least one non-alphanumeric character
    //Example: "Security Key" must contain at least one non-alphanumeric character
    //الگو : {0} باید حداقل یک کاراکتر غیر حرف و عدد داشته باشد
    //مثال : "کلید امنیتی" باید حداقل یک کاراکتر غیر حرف و عدد داشته باشد
    public const string VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC = nameof(VALIDATION_ERROR_STRING_MUST_HAS_NON_ALPHA_NUMERIC);

    //Pattern: {0} must contain unique characters
    //Example: "Constellation Code" must contain unique characters
    //الگو : {0} باید کاراکترهای منحصر به فرد داشته باشد
    //مثال : "کد صورت فلکی" باید کاراکترهای منحصر به فرد داشته باشد
    public const string VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR = nameof(VALIDATION_ERROR_STRING_MUST_HAS_UNIQUE_CHAR);

    //Pattern: Appropriate length of {0} for {1} in {2} in {3} should be less than or equal to {4}
    //Example: Appropriate length of "Code" for "Moon" in "Moons of" "Jupiter" should be less than or equal to "5"
    //الگو : طول مناسب {0} برای {1} در {2} در {3} باید کمتر یا مساوی {4} باشد
    //مثال : طول مناسب "کد" برای "قمر" در "اقمار" "مشتری" باید کمتر یا مساوی "5" باشد
    public const string VALIDATION_ERROR_STRING_LENGTH_FOR_IN_SUBSET = nameof(VALIDATION_ERROR_STRING_LENGTH_FOR_IN_SUBSET);
    #endregion

    #region Number Validations
    //Pattern: {0} must be equal to {1}
    //Example: "Number of moons" must be equal to "1"
    //الگو : {0} باید برابر {1} باشد
    //مثال : "تعداد قمرها" باید برابر "1" باشد
    public const string VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO = nameof(VALIDATION_ERROR_NUMBER_NOT_EQUAL_TO);

    //Pattern: {0} must be between {1} and {2}
    //Example: "Planet distance from Sun" must be between "0.39" and "30.07"
    //الگو : {0} باید بین {1} و {2} باشد
    //مثال : "فاصله سیاره از خورشید" باید بین "0.39" و "30.07" باشد
    public const string VALIDATION_ERROR_NUMBER_BETWEEN = nameof(VALIDATION_ERROR_NUMBER_BETWEEN);

    //Pattern: {0} must be less than {1}
    //Example: "Planet radius" must be less than "70000"
    //الگو : {0} باید کمتر از {1} باشد
    //مثال : "شعاع سیاره" باید کمتر از "70000" باشد
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN);

    //Pattern: {0} must be less than or equal to {1}
    //Example: "Star magnitude" must be less than or equal to "6"
    //الگو : {0} باید کمتر یا مساوی {1} باشد
    //مثال : "قدر ستاره" باید کمتر یا مساوی "6" باشد
    public const string VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_LESS_THAN_OR_EQUAL_THAN);

    //Pattern: {0} must be greater than {1}
    //Example: "Galaxy diameter" must be greater than "0"
    //الگو : {0} باید بزرگتر از {1} باشد
    //مثال : "قطر کهکشان" باید بزرگتر از "0" باشد
    public const string VALIDATION_ERROR_NUMBER_GREATER_THAN = nameof(VALIDATION_ERROR_NUMBER_GREATER_THAN);

    //Pattern: {0} must be greater than or equal to {1}
    //Example: "Country population" must be greater than or equal to "0"
    //الگو : {0} باید بزرگتر یا مساوی {1} باشد
    //مثال : "جمعیت کشور" باید بزرگتر یا مساوی "0" باشد
    public const string VALIDATION_ERROR_NUMBER_GREATER_OR_EQUAL_THAN = nameof(VALIDATION_ERROR_NUMBER_GREATER_OR_EQUAL_THAN);
    #endregion

    #region Date Validations
    //Pattern: {0} must be less than {1}
    //Example: "Planet discovery date" must be less than "2025/01/01"
    //الگو : {0} باید کمتر از {1} باشد
    //مثال : "تاریخ کشف سیاره" باید کمتر از "2025/01/01" باشد
    public const string VALIDATION_ERROR_DATE_LESS_THAN = nameof(VALIDATION_ERROR_DATE_LESS_THAN);

    //Pattern: {0} must be less than or equal to {1}
    //Example: "Space mission end date" must be less than or equal to "2025/12/31"
    //الگو : {0} باید کمتر یا مساوی {1} باشد
    //مثال : "تاریخ پایان مأموریت فضایی" باید کمتر یا مساوی "2025/12/31" باشد
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL);

    //Pattern: {0} must be less than today
    //Example: "Country independence date" must be less than today
    //الگو : {0} باید کمتر از امروز باشد
    //مثال : "تاریخ استقلال کشور" باید کمتر از امروز باشد
    public const string VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_TO_TODAY);

    //Pattern: {0} must be less than or equal to today
    //Example: "Observatory establishment date" must be less than or equal to today
    //الگو : {0} باید کمتر یا مساوی امروز باشد
    //مثال : "تاریخ تأسیس رصدخانه" باید کمتر یا مساوی امروز باشد
    public const string VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_LESS_THAN_OR_EQUAL_TO_TODAY);

    //Pattern: {0} must be greater than {1}
    //Example: "Space mission end date" must be greater than "Space mission start date"
    //الگو : {0} باید بزرگتر از {1} باشد
    //مثال : "تاریخ پایان مأموریت فضایی" باید بزرگتر از "تاریخ شروع مأموریت فضایی" باشد
    public const string VALIDATION_ERROR_DATE_GREATER_THAN = nameof(VALIDATION_ERROR_DATE_GREATER_THAN);

    //Pattern: {0} must be greater than or equal to {1}
    //Example: "Satellite launch date" must be greater than or equal to "Project approval date"
    //الگو : {0} باید بزرگتر یا مساوی {1} باشد
    //مثال : "تاریخ پرتاب ماهواره" باید بزرگتر یا مساوی "تاریخ تصویب پروژه" باشد
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL);

    //Pattern: {0} must be greater than today
    //Example: "Space exploration date" must be greater than today
    //الگو : {0} باید بزرگتر از امروز باشد
    //مثال : "تاریخ کاوش فضایی" باید بزرگتر از امروز باشد
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_TO_TODAY);

    //Pattern: {0} must be greater than or equal to today
    //Example: "Telescope operation start date" must be greater than or equal to today
    //الگو : {0} باید بزرگتر یا مساوی امروز باشد
    //مثال : "تاریخ شروع عملیات تلسکوپ" باید بزرگتر یا مساوی امروز باشد
    public const string VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY = nameof(VALIDATION_ERROR_DATE_GREATER_THAN_OR_EQUAL_TO_TODAY);
    #endregion
}