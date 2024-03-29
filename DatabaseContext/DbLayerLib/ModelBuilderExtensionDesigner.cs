﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.Models;

namespace DbLayerLib
{
    public static class ModelBuilderExtensionDesigner
    {
        public static void BuilderExtensionDesigner(this ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<DocumentPropertyMainBodyModelDB>()
                .HasOne(u => u.PropertyLink)
                .WithOne(p => p.OwnerPropertyMainBody)
                .HasForeignKey<DocumentPropertyLinkModelDB>(p => p.OwnerPropertyMainBodyId);

            modelBuilder
                .Entity<DocumentPropertyGridModelDB>()
                .HasOne(u => u.PropertyLink)
                .WithOne(p => p.OwnerPropertyMainGrid)
                .HasForeignKey<DocumentPropertyLinkModelDB>(p => p.OwnerPropertyMainGridId);

            modelBuilder
                .Entity<DocumentPropertyLinkModelDB>()
                .HasOne(u => u.TypedEnum)
                .WithMany(p => p.PropertiesTypesLinks)
                .HasForeignKey(p => p.TypedEnumId);

            modelBuilder
                .Entity<DocumentPropertyLinkModelDB>()
                .HasOne(u => u.TypedDocument)
                .WithMany(p => p.PropertiesTypesLinks)
                .HasForeignKey(p => p.TypedDocumentId);
#if DEMO
            modelBuilder.HasDemoData();
#endif
        }

        /// <summary>
        /// Инициализировать DEMO данными базу даных
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void HasDemoData(this ModelBuilder modelBuilder)
        {
            Random? rand = new();

            int projects_num = 35;
            IEnumerable<ProjectModelDB> demo_projects = Enumerable.Range(1, projects_num).Select(x => new ProjectModelDB($"Demo project {x}", $"Description project {x}") { Id = x, NameSpace = $"Test{x}.DemoNameSpace", IsDeleted = rand.Next(100) <= 15 });
            modelBuilder.Entity<ProjectModelDB>().HasData(demo_projects);

            UserModelDB[] users_demo = new UserModelDB[]
            {
                new UserModelDB("222") { Id = 1 },
                new UserModelDB("Bob") { Id = 2 },
                new UserModelDB("Sam") { Id = 3 },
                new UserModelDB("Kelly") { Id = 4 },
                new UserModelDB("David") { Id = 5 },
                new UserModelDB("Rokki") { Id = 6 }
            };
            modelBuilder.Entity<UserModelDB>().HasData(users_demo);

            UserMetaModelDB[] user_metadata_demo = new UserMetaModelDB[]
            {
                new UserMetaModelDB() { Id = 1, Email = "badhitman@yandex.ru", AccessLevelUser = AccessLevelsUsersEnum.ROOT, UserId = 1, ConfirmationType = ConfirmationUsersTypesEnum.Email },
                new UserMetaModelDB() { Id = 2, Email = "bobb@mail.ru", AccessLevelUser = AccessLevelsUsersEnum.Confirmed, UserId = 2, ConfirmationType = ConfirmationUsersTypesEnum.Email },
                new UserMetaModelDB() { Id = 3, Email = "samuel@mail.ru", AccessLevelUser = AccessLevelsUsersEnum.Trusted, UserId = 3, ConfirmationType = ConfirmationUsersTypesEnum.Email },
                new UserMetaModelDB() { Id = 4, Email = "kiki@mail.ru", AccessLevelUser = AccessLevelsUsersEnum.Manager, UserId = 4, ConfirmationType = ConfirmationUsersTypesEnum.Email },
                new UserMetaModelDB() { Id = 5, Email = "diablo@mail.ru", AccessLevelUser = AccessLevelsUsersEnum.Admin, UserId = 5 , ConfirmationType = ConfirmationUsersTypesEnum.Email },
                new UserMetaModelDB() { Id = 6, Email = "ronin@mail.ru", AccessLevelUser = AccessLevelsUsersEnum.Blocked, UserId = 6 , ConfirmationType = ConfirmationUsersTypesEnum.Email }
            };
            modelBuilder.Entity<UserMetaModelDB>().HasData(user_metadata_demo);

            UserProfileModelDB[] user_profiles = new UserProfileModelDB[]
            {
                new UserProfileModelDB() { Id = 1, Login = "222222222", UserId = 1 },
                new UserProfileModelDB() { Id = 2, Login = "bobb", UserId = 2 },
                new UserProfileModelDB() { Id = 3, Login = "samuel", UserId = 3 },
                new UserProfileModelDB() { Id = 4, Login = "kiki", UserId = 4 },
                new UserProfileModelDB() { Id = 5, Login = "diablo", UserId = 5 },
                new UserProfileModelDB() { Id = 6, Login = "tom", UserId = 6 }
            };
            modelBuilder.Entity<UserProfileModelDB>().HasData(user_profiles);

            UserPasswordModelDb[] passwords_demo = new UserPasswordModelDb[]
            {
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("222222222"), Id = 1, UserId = 1 },
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("gsdfghjg"), Id = 2, UserId = 2 },
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("hdg6hw46s"), Id = 3, UserId = 3 },
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("dh6jwk45"), Id = 4, UserId = 4 },
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("dfgh6qeh"), Id = 5, UserId = 5 },
                new UserPasswordModelDb() { Hash = GlobalUtils.CalculateHashString("ffsgfgggragf"), Id = 6, UserId = 6 }
            };
            modelBuilder.Entity<UserPasswordModelDb>().HasData(passwords_demo);

            Array values = Enum.GetValues(typeof(AccessLevelsUsersToProjectsEnum));

            List<(ProjectModelDB project, int user_id)> rand_links = demo_projects.SelectMany(x => Enumerable.Range(1, 6).Select(y => (x, y))).ToList();
            rand_links.Shuffle(); rand_links.Shuffle(); rand_links.Shuffle();
            rand_links = rand_links.Take(projects_num * 3).ToList();
            int log_change_index_id = 0;

            List<LogChangeModelDB> change_logs = new(demo_projects.Select(x => new LogChangeModelDB() { Id = ++log_change_index_id, OwnerType = ContextesChangeLogEnum.Project, OwnerId = x.Id, Name = $"Создан проект (demo HasData)", Description = $"[name:{x.Name}] [ns:{x.NameSpace}] [descr:{x.Description}]" }));

            int index_id = 0;
            IEnumerable<UserToProjectLinkModelDb> users_to_project_link = rand_links.Select(x => new UserToProjectLinkModelDb()
            {
                Id = ++index_id,
                ProjectId = x.project.Id,
                UserId = x.user_id,
                IsDeleted = rand.Next(100) <= 20,
                AccessLevelUser = (AccessLevelsUsersToProjectsEnum)values.GetValue(rand.Next(values.Length))
            });
            modelBuilder.Entity<UserToProjectLinkModelDb>().HasData(users_to_project_link);

            UserModelDB curr_user;
            change_logs.AddRange(users_to_project_link.Select(x =>
            {
                curr_user = users_demo.First(u => u.Id == x.UserId);
                return new LogChangeModelDB()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Project,
                    OwnerId = x.ProjectId,
                    Name = $"Добавлен пользователь к проекту (demo HasData)",
                    Description = $"[is_del:{x.IsDeleted}] [level:{x.AccessLevelUser}] [user: #{x.UserId} {curr_user.Name}]"
                };
            }));

            index_id = 0;
            EnumDesignModelDB[] enums_demo_data = demo_projects.SelectMany(project => Enumerable.Range(1, rand.Next(34, 40)).Select(enum_num => new EnumDesignModelDB()
            {
                Id = ++index_id,
                Description = $"Description enum {index_id}",
                Name = $"Enum name '{index_id}'",
                SystemCodeName = $"Enum{index_id}",
                ProjectId = project.Id,
                IsDeleted = rand.Next(1, 100) > 70
            })).ToArray();
            modelBuilder.Entity<EnumDesignModelDB>().HasData(enums_demo_data);

            change_logs.AddRange(enums_demo_data.Select(x =>
            {
                return new LogChangeModelDB()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Enum,
                    OwnerId = x.Id,
                    Name = $"Добавлено перечисление (demo HasData)",
                    Description = $"[is_del:{x.IsDeleted}] [code:{x.SystemCodeName}]"
                };
            }));

            index_id = 0;
            List<EnumDesignItemModelDB> enums_items_demo_data = enums_demo_data.SelectMany(x =>
            {
                uint sort_index = 0;
                return Enumerable.Range(1, rand.Next(4, 12)).Select(y => new EnumDesignItemModelDB()
                {
                    SortIndex = sort_index++,
                    OwnerEnumId = x.Id,
                    Id = ++index_id,
                    Name = $"EnumItemElement_{y}_Enum",
                    Description = $"Enum item/element {y}",
                    IsDeleted = rand.Next(1, 100) > 70
                });
            }).ToList();
            modelBuilder.Entity<EnumDesignItemModelDB>().HasData(enums_items_demo_data);

            change_logs.AddRange(enums_items_demo_data.Select(x =>
            {
                return new LogChangeModelDB()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Enum,
                    OwnerId = x.OwnerEnumId,
                    Name = $"Добавлен элемент перечисления (demo HasData)",
                    Description = $"[name:{x.Name}] [descr:{x.Description}] [is_del:{x.IsDeleted}] [index:{x.SortIndex}]"
                };
            }));

            index_id = 0;
            DocumentDesignModelDB[] documents_demo_data = demo_projects.SelectMany(project => Enumerable.Range(1, rand.Next(14, 40)).Select(enum_num => new DocumentDesignModelDB()
            {
                Id = ++index_id,
                Description = $"Description document {index_id}",
                Name = $"Document name '{index_id}'",
                SystemCodeName = $"Document{index_id}_Model",
                ProjectId = project.Id,
                IsDeleted = rand.Next(1, 100) > 70
            })).ToArray();
            modelBuilder.Entity<DocumentDesignModelDB>().HasData(documents_demo_data);

            change_logs.AddRange(documents_demo_data.Select(x =>
            {
                return new LogChangeModelDB()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = x.Id,
                    Name = $"Создан документ (demo HasData)",
                    Description = $"[name:{x.Name}] [descr:{x.Description}] [is_del:{x.IsDeleted}] [code:{x.SystemCodeName}]"
                };
            }));

            int links_index_id = 0;
            PropertyTypesEnum[] enums_types = Enum.GetValues<PropertyTypesEnum>();
            int project_id;
            IEnumerable<EnumDesignModelDB> enums_for_project;
            IEnumerable<DocumentDesignModelDB> docs_for_project;
            List<DocumentPropertyLinkModelDB> props_links = new();

            index_id = 0;
            DocumentPropertyMainBodyModelDB[] doc_props_demo_data_body = documents_demo_data.SelectMany(x =>
            {
                uint sort_index2 = 0;
                return Enumerable.Range(3, rand.Next(3, 11)).Select(y => new DocumentPropertyMainBodyModelDB()
                {
                    PropertyType = enums_types[rand.Next(0, enums_types.Length)],
                    Id = ++index_id,
                    DocumentOwnerId = x.Id,
                    IsDeleted = rand.Next(1, 100) > 70,
                    SystemCodeName = $"DocumentMainBody{index_id}_Property",
                    Description = $"Description document prop (main body) {index_id}",
                    Name = $"Document prop (main body) name '{index_id}'",
                    SortIndex = ++sort_index2
                });
            }).ToArray();
            foreach (DocumentPropertyMainBodyModelDB el in doc_props_demo_data_body)
            {
                project_id = documents_demo_data.First(x => x.Id == el.DocumentOwnerId).ProjectId;
                switch (el.PropertyType)
                {
                    case PropertyTypesEnum.SimpleEnum:
                        enums_for_project = enums_demo_data.Where(x => x.ProjectId == project_id);
                        if (!enums_for_project.Any())
                            break;

                        links_index_id++;
                        props_links.Add(new DocumentPropertyLinkModelDB()
                        {
                            TypedEnumId = enums_for_project.ElementAt(rand.Next(0, enums_for_project.Count())).Id,
                            Id = links_index_id,
                            OwnerPropertyMainBodyId = el.Id
                        });
                        el.PropertyLinkId = links_index_id;
                        break;
                    case PropertyTypesEnum.Document:
                        docs_for_project = documents_demo_data.Where(x => x.ProjectId == project_id && x.Id != el.DocumentOwnerId);
                        if (!docs_for_project.Any())
                            break;

                        links_index_id++;
                        props_links.Add(new DocumentPropertyLinkModelDB()
                        {
                            TypedDocumentId = docs_for_project.ElementAt(rand.Next(0, docs_for_project.Count())).Id,
                            Id = links_index_id,
                            OwnerPropertyMainBodyId = el.Id,
                        });
                        el.PropertyLinkId = links_index_id;
                        break;
                    default:

                        break;
                }
            }
            modelBuilder.Entity<DocumentPropertyMainBodyModelDB>().HasData(doc_props_demo_data_body);

            DocumentPropertyLinkModelDB prop_link;
            change_logs.AddRange(doc_props_demo_data_body.Select(x =>
            {
                LogChangeModelDB log_obj = new()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = x.DocumentOwnerId,
                    Name = $"Создано поле тела документа (demo HasData)",
                    Description = $"[name:{x.Name}] [type:{x.PropertyType}] [descr:{x.Description}] [is_del:{x.IsDeleted}] [code:{x.SystemCodeName}]"
                };

                prop_link = x.PropertyType == PropertyTypesEnum.Document || x.PropertyType == PropertyTypesEnum.SimpleEnum
                ? props_links.First(z => z.Id == x.PropertyLinkId)
                : null;

                log_obj.Description += x.PropertyType switch
                {
                    PropertyTypesEnum.SimpleEnum => $"[enum:#{prop_link.TypedEnumId} {enums_demo_data.First(y => y.Id == prop_link.TypedEnumId).Name}]",
                    PropertyTypesEnum.Document => $"[doc:#{prop_link.TypedDocumentId} {documents_demo_data.First(y => y.Id == prop_link.TypedDocumentId).Name}]",
                    _ => string.Empty
                };

                return log_obj;
            }));

            index_id = 0;
            DocumentGridModelDB[] docs_grids = documents_demo_data.SelectMany(x =>
            {
                return Enumerable.Range(1, rand.Next(2, 4)).Select(y => new DocumentGridModelDB()
                {
                    Id = ++index_id,
                    DocumentOwnerId = x.Id,
                    IsDeleted = rand.Next(1, 100) > 70,
                    SystemCodeName = $"Grid{index_id}ForDocument{x.Id}",
                    Description = $"Description grid document{index_id}",
                    Name = $"Document grid name '{index_id}'"
                });
            }).ToArray();

            index_id = 0;
            DocumentPropertyGridModelDB[] doc_props_demo_data_grid = docs_grids.SelectMany(x =>
            {
                change_logs.Add(new LogChangeModelDB()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = x.DocumentOwnerId,
                    Name = $"Создана табличная часть документа (demo HasData)",
                    Description = $"[name:{x.Name}] [descr:{x.Description}] [is_del:{x.IsDeleted}] [code:{x.SystemCodeName}]"
                });

                uint sort_index2 = 0;
                return Enumerable.Range(3, rand.Next(2, 3)).Select(y => new DocumentPropertyGridModelDB()
                {
                    PropertyType = enums_types[rand.Next(0, enums_types.Length)],
                    Id = ++index_id,
                    GridId = x.Id,
                    Grid = x,
                    IsDeleted = rand.Next(1, 100) > 70,
                    SystemCodeName = $"DocumentGrid{index_id}_Property",
                    Description = $"Description document prop (main grid) {index_id}",
                    Name = $"Document prop (main grid) name '{index_id}'",
                    SortIndex = ++sort_index2
                });
            }).ToArray();
            foreach (DocumentPropertyGridModelDB el in doc_props_demo_data_grid)
            {
                project_id = documents_demo_data.First(x => x.Id == el.Grid.DocumentOwnerId).ProjectId;
                switch (el.PropertyType)
                {
                    case PropertyTypesEnum.SimpleEnum:
                        enums_for_project = enums_demo_data.Where(x => x.ProjectId == project_id);
                        if (!enums_for_project.Any())
                            break;

                        links_index_id++;
                        props_links.Add(new DocumentPropertyLinkModelDB()
                        {
                            TypedEnumId = enums_for_project.ElementAt(rand.Next(0, enums_for_project.Count())).Id,
                            Id = links_index_id,
                            OwnerPropertyMainGridId = el.Id
                        });
                        el.PropertyLinkId = links_index_id;
                        break;
                    case PropertyTypesEnum.Document:
                        docs_for_project = documents_demo_data.Where(x => x.ProjectId == project_id && x.Id != el.Grid.DocumentOwnerId);
                        if (!docs_for_project.Any())
                            break;

                        links_index_id++;
                        props_links.Add(new DocumentPropertyLinkModelDB()
                        {
                            TypedDocumentId = docs_for_project.ElementAt(rand.Next(0, docs_for_project.Count())).Id,
                            Id = links_index_id,
                            OwnerPropertyMainGridId = el.Id
                        });
                        el.PropertyLinkId = links_index_id;
                        break;
                    default:

                        break;
                }
            }
            modelBuilder.Entity<DocumentGridModelDB>().HasData(docs_grids);
            modelBuilder.Entity<DocumentPropertyLinkModelDB>().HasData(props_links);

            change_logs.AddRange(doc_props_demo_data_grid.Select(x =>
            {
                LogChangeModelDB log_obj = new()
                {
                    Id = ++log_change_index_id,
                    OwnerType = ContextesChangeLogEnum.Document,
                    OwnerId = x.Grid.DocumentOwnerId,
                    Name = $"Создано поле табличной части документа (demo HasData)",
                    Description = $"[name:{x.Name}] [type:{x.PropertyType}] [descr:{x.Description}] [is_del:{x.IsDeleted}] [code:{x.SystemCodeName}]"
                };

                prop_link = x.PropertyType == PropertyTypesEnum.Document || x.PropertyType == PropertyTypesEnum.SimpleEnum
                ? props_links.First(z => z.Id == x.PropertyLinkId)
                : null;

                log_obj.Description += x.PropertyType switch
                {
                    PropertyTypesEnum.SimpleEnum => $"[enum:#{prop_link.TypedEnumId} {enums_demo_data.First(y => y.Id == prop_link.TypedEnumId).Name}]",
                    PropertyTypesEnum.Document => $"[doc:#{prop_link.TypedDocumentId} {documents_demo_data.First(y => y.Id == prop_link.TypedDocumentId).Name}]",
                    _ => string.Empty
                };

                return log_obj;
            }));

            doc_props_demo_data_grid = doc_props_demo_data_grid.Select(x => { x.Grid = null; return x; }).ToArray();
            modelBuilder.Entity<DocumentPropertyGridModelDB>().HasData(doc_props_demo_data_grid);

            change_logs.ForEach(x => { x.AuthorId = 1; });
            modelBuilder.Entity<LogChangeModelDB>().HasData(change_logs);
        }
    }
}