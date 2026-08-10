using ContactsApp.Models;
using ContactsApp.Repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ContactRepository contactRepository = new ContactRepository();

app.MapGet("/api/contacts", () =>
{
    List<Contact> contacts = contactRepository.GetAllContacts();
    return Results.Ok(contacts);
});

app.MapGet("/api/contacts/{id}", (int id) =>
{
    Contact? contact = contactRepository.GetContactById(id);
    return contact != null ? Results.Ok(contact) : Results.NotFound("Contact not found.");
});

app.MapPost("/api/contacts", (Contact contact) =>
{
    int rows = contactRepository.AddContact(contact);
    return rows > 0 ? Results.Ok("Contact added successfully.") : Results.BadRequest("Failed to add contact.");
});

app.MapPut("/api/contacts/{id}", (int id, Contact contact) =>
{
    int rows = contactRepository.UpdateContact(id, contact);
    return rows > 0 ? Results.Ok("Contact updated successfully.") : Results.NotFound("Contact not found.");
});

app.MapDelete("/api/contacts/{id}", (int id) =>
{
    int rows = contactRepository.DeleteContact(id);
    return rows > 0 ? Results.Ok("Contact deleted successfully.") : Results.NotFound("Contact not found.");
});

app.Run();