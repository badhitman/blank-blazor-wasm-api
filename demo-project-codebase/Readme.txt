Генератор C# комплекта - ver: 1.0.0 (by © https://github.com/badhitman - @fakegov)
============ 05.08.2022 19:36:06 ============

Перечислений: 34 (элементов всего: 266)
Документов: 20 (полей всего: 249)
- ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ - ~ -
enums - папка размещения файлов перечислений

access_table - папка размещения файлов сервисов backend служб доступа к данным (CRUD) и классов/моделей ответов rest контроллеров
	> crud_interfaces: интерфейсы низкоуровневого доступа к контексту таблиц базы данных
		> crud_implementations: реализация интерфейсов crud_interfaces
······················································
	> service_interfaces: интерфейсы функционального/промежуточного (между контроллером и низкоуровневым DB доуступом) доступа к данным
		> service_implementations: реализация интерфейсов service_interfaces
······················································
	response_models: модели ответов контроллеров, которые в свою очередь получают их от функциональных/промежуточных служб доступа
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

refit - папака размещения файлов клиентских/Refit служб для взаимодействия с api/rest контроллерами

LayerContextPartGen.cs - разделяемый [public partial class LayerContext : DbContext] класс.
refit_di.cs - [public static class RefitExtensionDesignerDI].[public static void BuildRefitServicesDI(this IServiceCollection services, ClientConfigModel conf, TimeSpan handler_lifetime)]
services_di.cs - [public static class ServicesExtensionDesignerDI].[public static void BuildDesignerServicesDI(this IServiceCollection services)]
