////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Models
{
    /// <summary>
    /// Поле/свойтво (основное) в таблице документа
    /// </summary>    
    [Table("DesignDocumentsMainGridProperties")]
    [Comment("Реквизиты документов (основная табличная часть)")]
    [Index(nameof(PropertyLinkId))]
    public class DocumentPropertyMainGridModelDB : DocumentPropertyMainModelDB
    {
        
    }
}