////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Связи полей документов с вещественными типами данных
    /// </summary>
    [Index(nameof(TypedEnumId)), Index(nameof(TypedDocumentId))]
    public class DocumentPropertyLinkModelDB
    {
        /// <summary>
        /// Идентификатор/Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        public int? OwnerPropertyMainBodyId { get; set; }

        public DocumentPropertyMainBodyModelDB? OwnerPropertyMainBody { get; set; }
        /// <summary>
        /// Поле/свойство (владелец) табличной части документа.
        /// NULL если владелец - тело документа
        /// </summary>
        public int? OwnerPropertyMainGridId { get; set; }
        /// <summary>
        /// Поле/свойство (владелец) тела документа.
        /// NULL если владелец - табличная часть документа
        /// </summary>
        public DocumentPropertyMainGridModelDB? OwnerPropertyMainGrid { get; set; }

        /// <summary>
        /// Идентификатор тип:перечисления.
        /// NULL - если тип данных не перечисление
        /// </summary>
        public int? TypedEnumId { get; set; }
        /// <summary>
        /// Тип:перечисление. Ссылка на объект перечисления, котрый представляет тип данных, хранящийся в поле/свойсвте документа.
        /// NULL - если тип данных не перечисление
        /// </summary>
        public EnumDesignModelDB? TypedEnum { get; set; }

        /// <summary>
        /// Идентификато типа:документа
        /// NULL - если тип данных не документ
        /// </summary>
        public int? TypedDocumentId { get; set; }
        /// <summary>
        /// Тип:документ. Ссылка на объект документа, котрый представляет тип данных, хранящийся в поле/свойсвте документа.
        /// NULL - если тип данных не документ
        /// </summary>
        public DocumentDesignModelDB? TypedDocument { get; set; }

        public int? TypeId
        {
            get
            {
                if (TypedDocumentId.GetValueOrDefault(0) > 0)
                    return TypedDocumentId;
                if (TypedEnumId.GetValueOrDefault(0) > 0)
                    return TypedEnumId;

                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="link1"></param>
        /// <param name="link2"></param>
        /// <returns></returns>
        public static bool operator ==(DocumentPropertyLinkModelDB link1, DocumentPropertyLinkModelDB link2)
        {
            return link1.TypedEnumId == link2.TypedEnumId && link1.TypedDocumentId == link2.TypedDocumentId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop_link1"></param>
        /// <param name="prop_link2"></param>
        /// <returns></returns>
        public static bool operator !=(DocumentPropertyLinkModelDB prop_link1, DocumentPropertyLinkModelDB prop_link2) => !(prop_link1?.TypedEnumId == prop_link2?.TypedEnumId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool Equals(object obj)
        {
            if(obj is not DocumentPropertyLinkModelDB || obj is null)
            {
                return false;
            }
            DocumentPropertyLinkModelDB other = obj as DocumentPropertyLinkModelDB;

            return this == other && Id == other.Id;
        }
    }
}