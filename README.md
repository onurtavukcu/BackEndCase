# BackEndCase
---
## What is Expected?

### This project is designed to book doctor appointments. 
Firstly get the doctor list from service. This service gives me doctors information. name, gender, nationality hospital etc..
After that check the doctors slot. Services works url with parameters. We can book and cancel appointments from doctors.
Also we use this service url with parameters. 

we preffered for this project ASP.Net. 
Use REST api and calling the endpoints, swaggerUI help us.

---

> Firstly we have to create a generic client service for serve GET and POST request. Base url certain. We have to get one location.
> We can use appsettings.json. If we want to add parameter we can add base url and we can GET or POST request.
> Deserialization of incoming data is also done here.

```
 public abstract class AbstractClientService
 {
     ....
     protected async Task<TReturn> GetAsync<TReturn>(string relativeUrl)
     {
	...
     }

     protected async Task<TReturn> PostAsync<TReturn, TRequest>(string relativeUrl)
     {
       ...
     }
```

Now we can get data from the service. Also create doctorlist, DoctorFreeSlots models. 
	(We have to guarantee incoming data models, data name and data type equals models props name and props data type) 

```
     await GetAsync<DoctorListWrapper>(relativeUrl);
     await GetAsync<DoctorFreeSlotsWrapper>(parameteredUrl);
```

---

> If can we get data from service, we can book or cancelled appointments. 
> For book appointments we need to BookingDetails. (send with url) 
     Also we need to transform datetime for url parameters. (dd/MM/yyyy, HH:mm) We create extensions for that.
< For cancel appointments we need to bookingId.

```
 return await PostAsync<CancellingResult, object>(relativeUrl + "BookingID=" + bookingId);
```

```
public async Task<BookingResult> BookAppointmentAsync(BookingDetails booking)
{
    StringBuilder query = new StringBuilder();

    query.Append($"VisitId={booking.VisitId}");
    query.Append($"&startTime={MinHourExtension.Transform(booking.startTime)}");
    query.Append($"&endTime={MinHourExtension.Transform(booking.endTime)}");
    query.Append($"&date={DateExtension.Transform(booking.endTime)}");
    query.Append($"&PatientName={booking.patient.PatientName}");
    query.Append($"&PatientSurname={booking.patient.PatientSurname}");
    query.Append($"&hospitalId={booking.hospitalId}");
    query.Append($"&doctorId={booking.doctorId}");
    query.Append($"&branchId={Convert.ToInt64(booking.branchId)}");

    string fullUrl = relativeUrl + query.ToString();

    return await PostAsync<BookingResult, object>(fullUrl);
}
```

### For the HR we need to export data as CSV files.

For this operation we need generic export operation. In case document says only doctor list export. But in future you need doctors free slots or another tables.

Firstly get list of data. Convert list to datatable. And return datatable to byte array. (because CSV file is not excel file. Its byte file)

Also for filtering column operation has own endpoint. You can filter any column and column value. (For example "nationality" column and "TUR" value)

If you want to filter you can send column name and value. Otherwise all data serve.

Here is constructor:

```
public ExportCSV(List<T> list, string columnName = "", string parameter = "")
```

```
 public byte[] ExportToCSV()
 {
     DataTable dataTable = ListToDataTable(_list, _columnName, _parameter);

     string csvContent = DataTableToCSV(dataTable);

     byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent);

     return csvBytes;
 }

 private DataTable ListToDataTable(List<T> list, string columnName, string parameters)
 private DataTable ListToDataTableWithFiltering(DataTable dataTable, string columnName, string parameters)
 private string DataTableToCSV(DataTable dataTable)
```


There are many things worth adding to the project.
- Database integration 
- Post data not with url, you have to send request body. its common use and best practice
	url: +visibility, caching, bookmarking, sort filter use -length limit, security, comlexity, encoding, creating url with by hand
	body: +flexible, security, complex data, seperation, UI side can use and define easyly - less visible, caching, parsing, compatibility
- UI implementation / Blazor pages
- In server; return certain error or message.


