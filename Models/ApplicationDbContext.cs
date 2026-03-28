using Microsoft.EntityFrameworkCore;

namespace DACS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ChatHistory> ChatHistories { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<PersonalityTest> PersonalityTests { get; set; }

        public DbSet<CareerQuestion> CareerQuestions { get; set; }
        public DbSet<CareerOption> CareerOptions { get; set; }
        public DbSet<CareerTestResult> CareerTestResults { get; set; }

        public DbSet<CareerSuggestion> CareerSuggestions { get; set; }

        public DbSet<UniversitySuggestion> UniversitySuggestions { get; set; }

        public DbSet<LearningPathStep> LearningPathSteps { get; set; }

        public DbSet<BannedWord> BannedWords { get; set; }

        public DbSet<FAQ> FAQs { get; set; }

        public DbSet<FinalYearQuestion> FinalYearQuestions { get; set; }
        public DbSet<FinalYearAnswer> FinalYearAnswers { get; set; }
        public DbSet<FinalYearTestResult> FinalYearTestResults { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<CareerQuestion>().HasData(
                new CareerQuestion { Id = 1, Content = "Bạn thích làm việc kiểu nào?" },
                new CareerQuestion { Id = 2, Content = "Bạn yêu thích hoạt động nào nhất?" },
                new CareerQuestion { Id = 3, Content = "Bạn thường giỏi việc gì hơn?" },
                new CareerQuestion { Id = 4, Content = "Bạn thích môi trường làm việc như thế nào?" },
                new CareerQuestion { Id = 5, Content = "Khi làm việc nhóm, bạn thường đảm nhận vai trò gì?" },
                new CareerQuestion { Id = 6, Content = "Môn học bạn thích nhất thời phổ thông là?" },
                new CareerQuestion { Id = 7, Content = "Bạn đánh giá bản thân là người thế nào?" },
                new CareerQuestion { Id = 8, Content = "Nếu có thời gian rảnh, bạn sẽ chọn làm gì?" },
                new CareerQuestion { Id = 9, Content = "Bạn muốn được công nhận vì điều gì?" },
                new CareerQuestion { Id = 10, Content = "Bạn thích giải quyết vấn đề bằng cách nào?" }
            );

            modelBuilder.Entity<CareerOption>().HasData(
                new CareerOption { Id = 1, Text = "Sáng tạo nội dung, thiết kế", Type = "Sáng tạo", CareerQuestionId = 1 },
                new CareerOption { Id = 2, Text = "Sửa chữa, vận hành máy móc", Type = "Kỹ thuật", CareerQuestionId = 1 },
                new CareerOption { Id = 3, Text = "Giúp đỡ, lắng nghe người khác", Type = "Xã hội", CareerQuestionId = 1 },
                new CareerOption { Id = 4, Text = "Vẽ tranh, viết truyện, dựng video", Type = "Sáng tạo", CareerQuestionId = 2 },
                new CareerOption { Id = 5, Text = "Lắp ráp thiết bị, thử nghiệm kỹ thuật", Type = "Kỹ thuật", CareerQuestionId = 2 },
                new CareerOption { Id = 6, Text = "Tổ chức sự kiện, hỗ trợ cộng đồng", Type = "Xã hội", CareerQuestionId = 2 },
                new CareerOption { Id = 7, Text = "Nghệ thuật, ngôn ngữ, tưởng tượng", Type = "Sáng tạo", CareerQuestionId = 3 },
                new CareerOption { Id = 8, Text = "Tính toán, phân tích, logic", Type = "Kỹ thuật", CareerQuestionId = 3 },
                new CareerOption { Id = 9, Text = "Giao tiếp, kết nối và chia sẻ", Type = "Xã hội", CareerQuestionId = 3 },
                new CareerOption { Id = 10, Text = "Tự do, linh hoạt, không gò bó", Type = "Sáng tạo", CareerQuestionId = 4 },
                new CareerOption { Id = 11, Text = "Kỹ luật, có hệ thống", Type = "Kỹ thuật", CareerQuestionId = 4 },
                new CareerOption { Id = 12, Text = "Tập thể, có tính tương tác cao", Type = "Xã hội", CareerQuestionId = 4 },
                new CareerOption { Id = 13, Text = "Ý tưởng, định hướng sáng tạo", Type = "Sáng tạo", CareerQuestionId = 5 },
                new CareerOption { Id = 14, Text = "Xử lý kỹ thuật, kỹ năng cụ thể", Type = "Kỹ thuật", CareerQuestionId = 5 },
                new CareerOption { Id = 15, Text = "Kết nối nhóm, tạo không khí", Type = "Xã hội", CareerQuestionId = 5 },
                new CareerOption { Id = 16, Text = "Văn, nghệ thuật", Type = "Sáng tạo", CareerQuestionId = 6 },
                new CareerOption { Id = 17, Text = "Toán, Tin học, Lý", Type = "Kỹ thuật", CareerQuestionId = 6 },
                new CareerOption { Id = 18, Text = "Sử, Địa, Giáo dục công dân", Type = "Xã hội", CareerQuestionId = 6 },
                new CareerOption { Id = 19, Text = "Sáng tạo, bay bổng", Type = "Sáng tạo", CareerQuestionId = 7 },
                new CareerOption { Id = 20, Text = "Chi tiết, chính xác", Type = "Kỹ thuật", CareerQuestionId = 7 },
                new CareerOption { Id = 21, Text = "Thấu cảm, nhiệt tình", Type = "Xã hội", CareerQuestionId = 7 },
                new CareerOption { Id = 22, Text = "Tạo video/TikTok/Youtube", Type = "Sáng tạo", CareerQuestionId = 8 },
                new CareerOption { Id = 23, Text = "Xem công nghệ mới", Type = "Kỹ thuật", CareerQuestionId = 8 },
                new CareerOption { Id = 24, Text = "Tham gia nhóm cộng đồng", Type = "Xã hội", CareerQuestionId = 8 },
                new CareerOption { Id = 25, Text = "Tác phẩm nghệ thuật, ý tưởng", Type = "Sáng tạo", CareerQuestionId = 9 },
                new CareerOption { Id = 26, Text = "Giải pháp kỹ thuật, lập trình", Type = "Kỹ thuật", CareerQuestionId = 9 },
                new CareerOption { Id = 27, Text = "Tác động tích cực đến người khác", Type = "Xã hội", CareerQuestionId = 9 },
                new CareerOption { Id = 28, Text = "Suy nghĩ sáng tạo, đưa ra ý tưởng", Type = "Sáng tạo", CareerQuestionId = 10 },
                new CareerOption { Id = 29, Text = "Áp dụng công nghệ, phân tích", Type = "Kỹ thuật", CareerQuestionId = 10 },
                new CareerOption { Id = 30, Text = "Trao đổi, hỏi ý kiến người khác", Type = "Xã hội", CareerQuestionId = 10 }
            );

            modelBuilder.Entity<CareerSuggestion>().HasData(
        new CareerSuggestion
        {
            Id = 1,
            CareerType = "Kỹ thuật",
            SuggestedMajors = "Công nghệ thông tin, Kỹ thuật phần mềm, Cơ điện tử",
            Resources = "https://www.freecodecamp.org/, https://viblo.asia/, Sách 'Cấu trúc dữ liệu và giải thuật'"
        },
        new CareerSuggestion
        {
            Id = 2,
            CareerType = "Sáng tạo",
            SuggestedMajors = "Thiết kế đồ họa, Kiến trúc, Truyền thông đa phương tiện",
            Resources = "https://www.canva.com/learn/, https://www.behance.net/, Sách 'Thiết kế ý tưởng sáng tạo'"
        },
        new CareerSuggestion
        {
            Id = 3,
            CareerType = "Xã hội",
            SuggestedMajors = "Luật, Quản trị nhân lực, Giáo dục học",
            Resources = "https://moet.gov.vn/, Sách 'Tâm lý học đại cương', https://www.edx.org/"
        }
    );


            modelBuilder.Entity<UniversitySuggestion>().HasData(
      // Kỹ thuật
      new UniversitySuggestion
      {
          Id = 1,
          DominantType = "Kỹ thuật",
          Major = "Công nghệ thông tin",
          UniversityName = "ĐH Bách Khoa TP.HCM",
          Website = "https://hcmut.edu.vn"
      },
      new UniversitySuggestion
      {
          Id = 2,
          DominantType = "Kỹ thuật",
          Major = "Kỹ thuật phần mềm",
          UniversityName = "ĐH Công Nghệ Thông Tin",
          Website = "https://uit.edu.vn"
      },

      // Sáng tạo
      new UniversitySuggestion
      {
          Id = 3,
          DominantType = "Sáng tạo",
          Major = "Thiết kế đồ họa",
          UniversityName = "ĐH Mỹ Thuật TP.HCM",
          Website = "http://hcmufa.edu.vn"
      },
      new UniversitySuggestion
      {
          Id = 4,
          DominantType = "Sáng tạo",
          Major = "Truyền thông đa phương tiện",
          UniversityName = "ĐH FPT",
          Website = "https://daihoc.fpt.edu.vn"
      },

      // Xã hội
      new UniversitySuggestion
      {
          Id = 5,
          DominantType = "Xã hội",
          Major = "Xã hội học",
          UniversityName = "ĐH Khoa học Xã hội & Nhân văn",
          Website = "https://hcmussh.edu.vn"
      },
      new UniversitySuggestion
      {
          Id = 6,
          DominantType = "Xã hội",
          Major = "Tâm lý học",
          UniversityName = "ĐH Sư phạm TP.HCM",
          Website = "https://hcmue.edu.vn"
      },

      // Quản lý
      new UniversitySuggestion
      {
          Id = 7,
          DominantType = "Quản lý",
          Major = "Quản trị kinh doanh",
          UniversityName = "ĐH Kinh tế TP.HCM",
          Website = "https://ueh.edu.vn"
      },

      // Thực tế
      new UniversitySuggestion
      {
          Id = 8,
          DominantType = "Thực tế",
          Major = "Nông nghiệp",
          UniversityName = "ĐH Nông Lâm TP.HCM",
          Website = "https://hcmuaf.edu.vn"
      },

      // Nghiên cứu
      new UniversitySuggestion
      {
          Id = 9,
          DominantType = "Nghiên cứu",
          Major = "Khoa học dữ liệu",
          UniversityName = "ĐH Quốc tế - ĐHQG TP.HCM",
          Website = "https://hcmiu.edu.vn"
      }
  );

            modelBuilder.Entity<LearningPathStep>().HasData(
    // ✅ Nhóm: Kỹ thuật (Realistic)
    new LearningPathStep { Id = 1, DominantType = "Kỹ thuật", YearStage = "Năm 1", Content = "Học Toán rời rạc, Tin học đại cương, Cơ sở lập trình" },
    new LearningPathStep { Id = 2, DominantType = "Kỹ thuật", YearStage = "Năm 2", Content = "Học Cấu trúc dữ liệu, OOP, Cơ sở dữ liệu, mạng máy tính" },
    new LearningPathStep { Id = 3, DominantType = "Kỹ thuật", YearStage = "Năm 3", Content = "Học Lập trình Web, AI/ML cơ bản, Dự án phần mềm" },
    new LearningPathStep { Id = 4, DominantType = "Kỹ thuật", YearStage = "Năm 4", Content = "Thực tập, khóa luận tốt nghiệp, học DevOps, học nâng cao ngành" },

    // ✅ Nhóm: Nghiên cứu (Investigative)
    new LearningPathStep { Id = 5, DominantType = "Nghiên cứu", YearStage = "Năm 1", Content = "Học Toán cao cấp, Khoa học cơ bản, kỹ năng nghiên cứu" },
    new LearningPathStep { Id = 6, DominantType = "Nghiên cứu", YearStage = "Năm 2", Content = "Học thống kê, phân tích số liệu, viết báo cáo khoa học" },
    new LearningPathStep { Id = 7, DominantType = "Nghiên cứu", YearStage = "Năm 3", Content = "Tham gia nghiên cứu thực tế, hội thảo khoa học" },
    new LearningPathStep { Id = 8, DominantType = "Nghiên cứu", YearStage = "Năm 4", Content = "Viết đề tài nghiên cứu, tham gia lab, chuẩn bị học cao học" },

    // ✅ Nhóm: Nghệ thuật (Artistic)
    new LearningPathStep { Id = 9, DominantType = "Nghệ thuật", YearStage = "Năm 1", Content = "Học mỹ thuật cơ bản, lý thuyết màu sắc, nhiếp ảnh cơ bản" },
    new LearningPathStep { Id = 10, DominantType = "Nghệ thuật", YearStage = "Năm 2", Content = "Học thiết kế đồ họa, làm dự án cá nhân sáng tạo" },
    new LearningPathStep { Id = 11, DominantType = "Nghệ thuật", YearStage = "Năm 3", Content = "Học dựng phim, thiết kế giao diện người dùng (UI/UX)" },
    new LearningPathStep { Id = 12, DominantType = "Nghệ thuật", YearStage = "Năm 4", Content = "Triển lãm cá nhân, làm portfolio, thực tập tại công ty thiết kế" },

    // ✅ Nhóm: Xã hội (Social)
    new LearningPathStep { Id = 13, DominantType = "Xã hội", YearStage = "Năm 1", Content = "Học kỹ năng giao tiếp, tâm lý học, làm việc nhóm" },
    new LearningPathStep { Id = 14, DominantType = "Xã hội", YearStage = "Năm 2", Content = "Học quản lý giáo dục, tổ chức sự kiện, cố vấn học tập" },
    new LearningPathStep { Id = 15, DominantType = "Xã hội", YearStage = "Năm 3", Content = "Tham gia CLB, hướng dẫn viên, công tác xã hội" },
    new LearningPathStep { Id = 16, DominantType = "Xã hội", YearStage = "Năm 4", Content = "Thực tập tại các tổ chức xã hội, lên kế hoạch đào tạo" },

    // ✅ Nhóm: Doanh nhân (Enterprising)
    new LearningPathStep { Id = 17, DominantType = "Doanh nhân", YearStage = "Năm 1", Content = "Học quản trị kinh doanh, tư duy phản biện, kỹ năng bán hàng" },
    new LearningPathStep { Id = 18, DominantType = "Doanh nhân", YearStage = "Năm 2", Content = "Học marketing, tài chính căn bản, quản lý dự án" },
    new LearningPathStep { Id = 19, DominantType = "Doanh nhân", YearStage = "Năm 3", Content = "Thực hành khởi nghiệp, pitching ý tưởng, quản trị nhân sự" },
    new LearningPathStep { Id = 20, DominantType = "Doanh nhân", YearStage = "Năm 4", Content = "Thực tập tại doanh nghiệp, triển khai dự án kinh doanh thật" },

    // ✅ Nhóm: Công sở (Conventional)
    new LearningPathStep { Id = 21, DominantType = "Công sở", YearStage = "Năm 1", Content = "Học tin học văn phòng, nguyên lý kế toán, hành chính căn bản" },
    new LearningPathStep { Id = 22, DominantType = "Công sở", YearStage = "Năm 2", Content = "Học kế toán tài chính, nghiệp vụ hành chính, quy trình văn thư" },
    new LearningPathStep { Id = 23, DominantType = "Công sở", YearStage = "Năm 3", Content = "Thực hành quản trị hồ sơ, kỹ năng viết văn bản hành chính" },
    new LearningPathStep { Id = 24, DominantType = "Công sở", YearStage = "Năm 4", Content = "Thực tập tại văn phòng, học phần mềm quản lý công việc" }


);
            // ===================== SEED CÂU HỎI CHO NĂM 3 & NĂM CUỐI =====================
            modelBuilder.Entity<FinalYearQuestion>().HasData(
                new FinalYearQuestion { Id = 1, Content = "Bạn đã có định hướng nghề nghiệp sau khi ra trường chưa?" },
                new FinalYearQuestion { Id = 2, Content = "Bạn đã từng tham gia thực tập hoặc dự án thực tế chưa?" },
                new FinalYearQuestion { Id = 3, Content = "Bạn đã chuẩn bị CV xin việc chưa?" },
                new FinalYearQuestion { Id = 4, Content = "Bạn có tham gia các hoạt động ngoại khóa hoặc CLB không?" },
                new FinalYearQuestion { Id = 5, Content = "Bạn có chứng chỉ ngoại ngữ (TOEIC/IELTS...) chưa?" },
                new FinalYearQuestion { Id = 6, Content = "Bạn có kỹ năng tin học văn phòng (Word, Excel, PowerPoint) ở mức nào?" },
                new FinalYearQuestion { Id = 7, Content = "Bạn có tham gia các workshop / seminar nghề nghiệp không?" },
                new FinalYearQuestion { Id = 8, Content = "Bạn có tự tin khi tham gia phỏng vấn không?" },
                new FinalYearQuestion { Id = 9, Content = "Bạn có định hướng học lên cao học hoặc học thêm chứng chỉ chuyên ngành không?" },
                new FinalYearQuestion { Id = 10, Content = "Bạn có kế hoạch phát triển kỹ năng mềm (teamwork, giao tiếp, quản lý thời gian) không?" }
            );

            modelBuilder.Entity<FinalYearAnswer>().HasData(
                // Q1
                new FinalYearAnswer { Id = 1, Content = "Rõ ràng", Score = 3, QuestionId = 1 },
                new FinalYearAnswer { Id = 2, Content = "Tạm thời", Score = 2, QuestionId = 1 },
                new FinalYearAnswer { Id = 3, Content = "Chưa có", Score = 1, QuestionId = 1 },

                // Q2
                new FinalYearAnswer { Id = 4, Content = "Có", Score = 3, QuestionId = 2 },
                new FinalYearAnswer { Id = 5, Content = "Dự định có", Score = 2, QuestionId = 2 },
                new FinalYearAnswer { Id = 6, Content = "Chưa", Score = 1, QuestionId = 2 },

                // Q3
                new FinalYearAnswer { Id = 7, Content = "Đã hoàn chỉnh", Score = 3, QuestionId = 3 },
                new FinalYearAnswer { Id = 8, Content = "Có nhưng chưa chỉnh chu", Score = 2, QuestionId = 3 },
                new FinalYearAnswer { Id = 9, Content = "Chưa có", Score = 1, QuestionId = 3 },

                // Q4
                new FinalYearAnswer { Id = 10, Content = "Có, thường xuyên", Score = 3, QuestionId = 4 },
                new FinalYearAnswer { Id = 11, Content = "Thỉnh thoảng", Score = 2, QuestionId = 4 },
                new FinalYearAnswer { Id = 12, Content = "Không", Score = 1, QuestionId = 4 },

                // Q5
                new FinalYearAnswer { Id = 13, Content = "Có", Score = 3, QuestionId = 5 },
                new FinalYearAnswer { Id = 14, Content = "Đang học để thi", Score = 2, QuestionId = 5 },
                new FinalYearAnswer { Id = 15, Content = "Chưa", Score = 1, QuestionId = 5 },

                // Q6
                new FinalYearAnswer { Id = 16, Content = "Thành thạo", Score = 3, QuestionId = 6 },
                new FinalYearAnswer { Id = 17, Content = "Trung bình", Score = 2, QuestionId = 6 },
                new FinalYearAnswer { Id = 18, Content = "Yếu", Score = 1, QuestionId = 6 },

                // Q7
                new FinalYearAnswer { Id = 19, Content = "Có, thường xuyên", Score = 3, QuestionId = 7 },
                new FinalYearAnswer { Id = 20, Content = "Đôi khi", Score = 2, QuestionId = 7 },
                new FinalYearAnswer { Id = 21, Content = "Không bao giờ", Score = 1, QuestionId = 7 },

                // Q8
                new FinalYearAnswer { Id = 22, Content = "Rất tự tin", Score = 3, QuestionId = 8 },
                new FinalYearAnswer { Id = 23, Content = "Bình thường", Score = 2, QuestionId = 8 },
                new FinalYearAnswer { Id = 24, Content = "Chưa tự tin", Score = 1, QuestionId = 8 },

                // Q9
                new FinalYearAnswer { Id = 25, Content = "Có kế hoạch rõ ràng", Score = 3, QuestionId = 9 },
                new FinalYearAnswer { Id = 26, Content = "Đang cân nhắc", Score = 2, QuestionId = 9 },
                new FinalYearAnswer { Id = 27, Content = "Chưa nghĩ tới", Score = 1, QuestionId = 9 },

                // Q10
                new FinalYearAnswer { Id = 28, Content = "Có kế hoạch & đang rèn luyện", Score = 3, QuestionId = 10 },
                new FinalYearAnswer { Id = 29, Content = "Có nghe nhưng chưa áp dụng", Score = 2, QuestionId = 10 },
                new FinalYearAnswer { Id = 30, Content = "Chưa quan tâm", Score = 1, QuestionId = 10 }
            );


        }




    }

}
