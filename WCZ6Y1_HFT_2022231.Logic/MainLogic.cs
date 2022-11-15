using System;
using System.Linq;
using WCZ6Y1_HFT_2022231.Models;
using WCZ6Y1_HFT_2022231.Repository;

namespace WCZ6Y1_HFT_2022231.Logic
{
    public class MainLogic : IMainLogic
    {
        IRepository<Author> authorRepo;
        IRepository<Publisher> publisherRepo;
        IRepository<Book> bookRepo;

        public MainLogic(IRepository<Author> authorRepo, IRepository<Publisher> publisherRepo, IRepository<Book> bookRepo)
        {
            this.authorRepo = authorRepo;
            this.publisherRepo = publisherRepo;
            this.bookRepo = bookRepo;
        }

        public void CreateAuthor(Author entity)
        {
            if (entity != null)
            {
                Author existingEntity = ReadAuthor(entity.AuthorId);
                if (existingEntity == null)
                {
                    authorRepo.Create(entity);
                }
                else
                {
                    throw new InvalidOperationException("Entity already exists");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity value is null");
            }
        }

        public void CreatePublisher(Publisher entity)
        {
            if (entity != null)
            {
                Publisher existingEntity = ReadPublisher(entity.PublisherId);
                if (existingEntity == null)
                {
                    publisherRepo.Create(entity);
                }
                else
                {
                    throw new InvalidOperationException("Entity already exists");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity value is null");
            }
        }

        public void CreateBook(Book entity)
        {
            if (entity != null)
            {
                Book existingEntity = ReadBook(entity.BookId);
                if (existingEntity == null)
                {
                    bookRepo.Create(entity);
                }
                else
                {
                    throw new InvalidOperationException("Entity already exists");
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Entity value is null");
            }
        }

        public void DeleteAuthor(int Id)
        {
            if (Id > 0)
            {
                Author existingEntity = ReadAuthor(Id);
                if (existingEntity != null)
                {
                    authorRepo.Remove(existingEntity);
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }

        public void DeletePublisher(int Id)
        {
            if (Id > 0)
            {
                Publisher existingEntity = ReadPublisher(Id);
                if (existingEntity != null)
                {
                    publisherRepo.Remove(existingEntity);
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }

        public void DeleteBook(int Id)
        {
            if (Id > 0)
            {
                Book existingEntity = ReadBook(Id);
                if (existingEntity != null)
                {
                    bookRepo.Remove(existingEntity);
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }

        public Author ReadAuthor(int Id)
        {
            return authorRepo.ReadOne(Id);
        }

        public IQueryable<Author> ReadAllAuthor()
        {
            return authorRepo.ReadAll();
        }

        public IQueryable<Publisher> ReadAllPublisher()
        {
            return publisherRepo.ReadAll();
        }

        public IQueryable<Book> ReadAllBook()
        {
            return bookRepo.ReadAll();
        }

        public Publisher ReadPublisher(int Id)
        {
            return publisherRepo.ReadOne(Id);
        }

        public Book ReadBook(int Id)
        {
            return bookRepo.ReadOne(Id);
        }

        public void UpdateAuthor(int oldEntityId, Author entity)
        {
            if (oldEntityId > 0)
            {
                Author exsistingEntity = ReadAuthor(oldEntityId);
                if (exsistingEntity != null)
                {
                    if (entity != null)
                    {
                        authorRepo.Update(exsistingEntity, entity);
                    }
                    else
                    {
                        throw new InvalidOperationException("Entity value is not valid");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }

        public void UpdatePublisher(int oldEntityId, Publisher entity)
        {
            if (oldEntityId > 0)
            {
                Publisher exsistingEntity = ReadPublisher(oldEntityId);
                if (exsistingEntity != null)
                {
                    if (entity != null)
                    {
                        publisherRepo.Update(exsistingEntity, entity);
                    }
                    else
                    {
                        throw new InvalidOperationException("Entity value is not valid");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }

        public void UpdateBook(int oldEntityId, Book entity)
        {
            if (oldEntityId > 0)
            {
                Book exsistingEntity = ReadBook(oldEntityId);
                if (exsistingEntity != null)
                {
                    if (entity != null)
                    {
                        bookRepo.Update(exsistingEntity, entity);
                    }
                    else
                    {
                        throw new InvalidOperationException("Entity value is not valid");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Entity does not exists");
                }
            }
            else
            {
                throw new ArgumentException("Id is not a valid value");
            }
        }
    }
}