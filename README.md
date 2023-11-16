# CRUD in using Entity Framework 

[CRUD C# Application Insert Update Delete Filter data in DataGridView using C# SQL Entity ADO.NET Data Model Framework, DevExpress Modern UI Design Winforms C# .NET Tutoria](https://www.youtube.com/watch?v=gWrrYkG7XV8&list=WL&index=1)

## 설명:  Entity Framework CRUD(DevExpress)
* This video show you how to update and insert data in database from datagridview in c# .net 
* or create a simple crud operations with sql server database.

* We will use Entity Framework, sql database, DevExpress Component to learn how to update database in c# topics such as:

1. how to insert data from datagridview to database in c#
2. how to edit update delete in datagridview in c# windows application
3. how to update row in datagridview in c# windows application
4. how to edit data in datagridview in c# windows application

* Use Entity Framework that helps you easy to insert update delete in c# windows form.

* This is a simple way to learn how to save datagridview data to database in c# windows application 
* or insert multiple rows from datagridview into database by using c# datagridview edit cell update database 
* or insert update and delete data with datagridview in windows form using c#

## 환경
* Visual Studio: [ ] 2019, [x] 2022
* 프로젝트 생성: [x] .Net Framework, [ ] .Net WinForm(windows form)
* Package 
  * [x] DevExpress 23.1
* NuGet
  * [ ] System.Data.SqlClient 
  * [ ] Dapper
  * [X] Entity Framework

## 작업
* Devexpress 일반 폼 생성 후  instance Layout Assistant 에서 
  *  위쪽은 Menu and Toolbar - bars 선택
  *  가운데는 Layout and Containers -> Data Layout Manager 선택
* 추가 -> 데이터 -> `ADO.NET 엔터티 데이터 모델` 선택
* 디자이너에서 dataLayoutControl1 선택 후 
  *  화살표 선택하면 추가 사항이 나오는데 `Select DataSource 선택 -> 프로젝트 데이터 소스 추가` 선택
  *  데이터베이스를 선택해서 추가
* 디자이너에서 dataLayoutControl1 선택 후 Select DataSource 선택 되었으면,
  *  화살표 선택해서 `Edit Fields` 선택 -> Field Name 에서 전체 선택해서 추가
  *  AddressTextEdit 디자인 모드에서 옮기기 화살표를 클릭해서 Size Constraints -> Lock Height
* GridControl 선택전에 LayoutControl을 하단에 추가 후 그 위에 GridControl 추가함.
* GridControl 선택해서 Chose DataSource 선택

* AddressTextEdit 디자인 모드에서 옮기기 화살표를 클릭해서 Size Constraints -> Lock Height
* gridView1 옵션 ShowAutoFilterRow = True