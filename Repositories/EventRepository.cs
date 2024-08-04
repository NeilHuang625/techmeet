using Microsoft.EntityFrameworkCore;
using techmeet.Data;
using techmeet.Models;
using Azure.Storage.Blobs;

namespace techmeet.Repositories{
    public class EventRepository : IEventRepository{
        private readonly EventContext _context;

        public EventRepository(EventContext context){
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync(){
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(int id){
            return await _context.Events.FirstOrDefaultAsync(e=>e.EventId == id);
        }

        public async Task AddEventAsync(Event evt, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                // create BlobServiceClient instance
                var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=techmeeteventpicture;AccountKey=QbfmPd6l1XBYxDMXEj8LeMpTjPhkhiK9l071GcgQydPECB3qd5d9TKGHXYOgi7XzKe4jrRKC3wl5+AStkBNkLA==;EndpointSuffix=core.windows.net");

                // create uploads container if not exists
                var blobContainerClient = blobServiceClient.GetBlobContainerClient("uploads");
                await blobContainerClient.CreateIfNotExistsAsync();

                // get BlobClient instance
                var blobClient = blobContainerClient.GetBlobClient(imageFile.FileName);

                // upload image file to Azure Blob Storage
                using (var stream = imageFile.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                // set ImagePath to the URL of the image file in Azure Blob Storage
                evt.ImagePath = blobClient.Uri.AbsoluteUri;
            }

            _context.Events.Add(evt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(Event evt, IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var blobServiceClient = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=techmeeteventpicture;AccountKey=QbfmPd6l1XBYxDMXEj8LeMpTjPhkhiK9l071GcgQydPECB3qd5d9TKGHXYOgi7XzKe4jrRKC3wl5+AStkBNkLA==;EndpointSuffix=core.windows.net");

                var blobContainerClient = blobServiceClient.GetBlobContainerClient("uploads");
                await blobContainerClient.CreateIfNotExistsAsync();

                var blobClient = blobContainerClient.GetBlobClient(imageFile.FileName);

                using (var stream = imageFile.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                // set ImagePath to the URL of the image file in Azure Blob Storage
                evt.ImagePath = blobClient.Uri.AbsoluteUri;
            }

            _context.Events.Update(evt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id){
            var evt = await _context.Events.FindAsync(id);
            if(evt != null){
                _context.Events.Remove(evt);
                await _context.SaveChangesAsync();
            }
        }
    }
}