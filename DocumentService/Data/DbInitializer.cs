using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentService.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Data.ApplicationDbContext context)
        {
            // context.Database.EnsureCreated();

            // Look for any members.
            if (context.HandyMember.Any())
            {
                return;   // DB has been seeded
            }

            var HandyMembers = new Models.HandyMember[]
            {
            new Models.HandyMember{FirstName="Carson",LastName="Alexander",DateOfBirth=DateTime.Parse("2005-09-01"),Email="abcd@hotmail.com",Phone="778-123-4567",Street="880 Granville St",City="Vancouver",ZIP="V3D 1N9",},
            new Models.HandyMember{FirstName="Meredith",LastName="Alonso",DateOfBirth=DateTime.Parse("2002-09-01"),Email="efgh@hotmail.com",Phone="778-123-4567",Street="880 Royal Oak St",City="Burnaby",ZIP="V3R 1E9"},
            new Models.HandyMember{FirstName="Arturo",LastName="Anand",DateOfBirth=DateTime.Parse("2003-09-01"),Email="ijk@hotmail.com",Phone="778-123-4567",Street="880 Granville St",City="Vancouver",ZIP="V3D 1N9"},
            new Models.HandyMember{FirstName="Gytis",LastName="Barzdukas",DateOfBirth=DateTime.Parse("2002-09-01"),Email="lmn@hotmail.com",Phone="778-123-4567",Street="880 Granville St",City="Vancouver",ZIP="V3D 1N9"},
            new Models.HandyMember{FirstName="Yan",LastName="Li",DateOfBirth=DateTime.Parse("2002-09-01"),Email="abcd@hotmail.com",Phone="778-123-4567",Street="880 Granville St",City="Vancouver",ZIP="V3D 1N9"},
           
            };
            foreach (Models.HandyMember s in HandyMembers)
            {
                context.HandyMember.Add(s);
            }
            context.SaveChanges();

            var JobTypes = new Models.JobType[]
            {
            new Models.JobType{TaskName="Plumbing",Category="Home Repair",Description="Fix pipes and fixtures"},
            new Models.JobType{TaskName="Landscaping",Category="Garden Work",Description="Apply pesticide, plant flowers, cut weed and lawn mowing"},
            new Models.JobType{TaskName="Lawn Mowing",Category="Garden Work",Description="Cut weed and lawn mowing"},
            new Models.JobType{TaskName="Snow Shoveling",Category="Garden Work",Description="Snow removal in garden and sidewalks"},
            
            };
            foreach (Models.JobType c in JobTypes)
            {
                context.JobType.Add(c);
            }
            context.SaveChanges();

            var MemberServices = new Models.MemberService[]
            {
            new Models.MemberService{HandyMemberID=1,JobTypeID=1,Rate=18.50m, Experience=2, Certificate=false},
            new Models.MemberService{HandyMemberID=1,JobTypeID=2,Rate=25.00m, Experience=2, Certificate=true},
            new Models.MemberService{HandyMemberID=1,JobTypeID=2,Rate=23.50m, Experience=2, Certificate=true},
            new Models.MemberService{HandyMemberID=2,JobTypeID=4,Rate=15.00m, Experience=2, Certificate=false},
            new Models.MemberService{HandyMemberID=2,JobTypeID=1,Rate=20.00m, Experience=2, Certificate=true},

            };
            foreach (Models.MemberService e in MemberServices)
            {
                context.MemberService.Add(e);
            }
            context.SaveChanges();
        }
    }
}
