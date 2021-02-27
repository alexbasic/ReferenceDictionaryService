using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Constants
{
    public static class Constants
    {
        /// <summary>
        /// Длина описания
        /// </summary>
        public const int DescriptionSize = 1024;

        /// <summary>
        /// Длина имени атрибута
        /// </summary>
        public const int AttributeNameSize = 256;

        /// <summary>
        /// Длина имени типа данных
        /// </summary>
        public const int DataTypeNameSize = 128;

        /// <summary>
        /// Длина строки паппинга типа данных
        /// </summary>
        public const int DataTypeMappingSize = 2048;

        /// <summary>
        /// Длина имени объекта
        /// </summary>
        public const int ObjectNameSize = 256;

        /// <summary>
        /// Размер данных атрибута
        /// </summary>
        public const int AttributeValueSize = 2048;

        /// <summary>
        /// Размер данных атрибута по умолчанию
        /// </summary>
        public const int AttributeDefaultValueSize = 256;

        /// <summary>
        /// Размер размер минимального значения атрибута
        /// </summary>
        public const int AttributeMinValueSize = 256;

        /// <summary>
        /// Размер размер максимального значения атрибута
        /// </summary>
        public const int AttributeMaxValueSize = 256;

        /// <summary>
        /// Размер данных в "большой" таблице
        /// </summary>
        public const int BigObjectDataSize = 1024 * 1024 * 10;

        /// <summary>
        /// Размер имени данных в "большой" таблице
        /// </summary>
        public const int BigObjectDataNameSize = 2048;
    }
}
