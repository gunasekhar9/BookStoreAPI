using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FeedbackRL : IFeedbackRL
    {
        private SqlConnection con;
        private readonly IConfiguration configuration;
        public FeedbackRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AddFeedback(FeedbackModel feedbackModel)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("AddFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", feedbackModel.id);
                    cmd.Parameters.AddWithValue("@BookId", feedbackModel.BookId);
                    cmd.Parameters.AddWithValue("@Comments", feedbackModel.Comments);
                    cmd.Parameters.AddWithValue("@OverallRating", feedbackModel.OverallRating);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 2)
                    {
                        return "An Error Occured";
                    }
                    else if (result == 1)
                    {
                        return "Your Feedback is already Registered";
                    }
                    else
                    {
                        return "Success:- Your Feedback is added Successfully";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }

        public List<GetFeedbackModel> GetFeedback(int BookId)
        {
            con = new SqlConnection(this.configuration.GetConnectionString("BookStore"));
            try
            {
                using (con)
                {
                    List<GetFeedbackModel> feedback = new List<GetFeedbackModel>();
                    SqlCommand cmd = new SqlCommand("GetFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookId", BookId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetFeedbackModel feedbackModel = new GetFeedbackModel();
                            FeedbackDetails details = new FeedbackDetails();
                            feedbackModel.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
                            feedbackModel.id = Convert.ToInt32(dr["id"]);
                            feedbackModel.BookId = Convert.ToInt32(dr["BookId"]);
                            feedbackModel.Comments = dr["Comments"].ToString();
                            feedbackModel.OverallRating = Convert.ToInt32(dr["Overallrating"]);
                            details.FullName = dr["FullName"].ToString();
                            details.EmailId = dr["EmailId"].ToString();
                            feedbackModel.details = details;
                            feedback.Add(feedbackModel);
                        }
                        return feedback;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }
        }
    }
    
}
