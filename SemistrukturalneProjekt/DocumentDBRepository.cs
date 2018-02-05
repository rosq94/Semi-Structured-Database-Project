using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using SemistrukturalneProjekt.Models;
using System.Web.Mvc;
using System.IO;

namespace SemistrukturalneProjekt
{
    public static class DBCounter
    {
        public static int KuchnieCount { get; set; }
        public static int LodówkiCount { get; set; }
        public static int MikseryCount { get; set; }
        public static int Pralko_SuszarkiCount { get; set; }
        public static int WirówkiCount { get; set; }
        public static int ZamrażarkiCount { get; set; }

        public static async Task Licznik()
        {
            //var item = await DocumentDBRepository<Counter>.GetItemAsync("01234");
            //if (item == null)
            //{
            //    Counter c = new Counter();
            //    c.CzyIstniejeLicznik = true;
            //    c.Id = "01234";
            //    c.KuchnieCount = 0;
            //    c.LodówkiCount = 0;
            //    c.MikseryCount = 0;
            //    c.Pralko_SuszarkiCount = 0;
            //    c.WirówkiCount = 0;
            //    c.ZamrażarkiCount = 0;
            //    await DocumentDBRepository<Counter>.CreateItemAsync(c);
            //    MikseryCount = item.MikseryCount;

            //}
            
            var Kuchnieitems = await DocumentDBRepository<Kuchnie>.GetItemsAsync(d => d.Rodzaj == "Kuchnia");
            var Lodówkiitems = await DocumentDBRepository<Lodówki>.GetItemsAsync(d => d.Rodzaj == "Lodówka");
            var Mikseryitems = await DocumentDBRepository<Miksery>.GetItemsAsync(d => d.Rodzaj == "Mikser");
            var Pralko_Suszarkiitems = await DocumentDBRepository<Pralko_Suszarki>.GetItemsAsync(d => d.Rodzaj == "Pralko-Suszarka");
            var Wirówkiitems = await DocumentDBRepository<Wirówki>.GetItemsAsync(d => d.Rodzaj == "Wirówka");
            var Zamrażarkiitems = await DocumentDBRepository<Zamrażarki>.GetItemsAsync(d => d.Rodzaj == "Zamrażarka");

            KuchnieCount = Kuchnieitems.Count();
            LodówkiCount = Lodówkiitems.Count();
            MikseryCount = Mikseryitems.Count();
            Pralko_SuszarkiCount = Pralko_Suszarkiitems.Count();
            WirówkiCount = Wirówkiitems.Count();
            ZamrażarkiCount = Zamrażarkiitems.Count();
        }
    }
    public static class DocumentDBRepository<T> where T : class
    {
        private static readonly string DatabaseId = ConfigurationManager.AppSettings["database"];
        private static readonly string CollectionId = ConfigurationManager.AppSettings["collection"];
        private static DocumentClient client;

        public static void Initialize()
        {
            client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["endpoint"]), ConfigurationManager.AppSettings["authKey"]);
            //CreateDatabaseIfNotExistsAsync().Wait();
            //CreateCollectionIfNotExistsAsync().Wait();

        }

        private static async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }

        public static async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId))
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }
            return results;
        }
        public static async Task<Document> CreateItemAsync(T item)
        {
            return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        public static async Task<Document> UpdateItemAsync(string id, T item)
        {
            return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }
        public static async Task<Document> DeleteItemAsync(string id, T item)
        {

            return await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        public static async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}