using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTracker.Repositories;
using WebTracker.Models;
using SignalR_Check.Models;
using Microsoft.Data.SqlClient;
//using WebTracker.Models;

namespace WebTracker.Repositories
{
    public class FlowDataRepository : IFlowDataRepository
    {
        private readonly WebTrackerDBContext _context;
        public FlowDataRepository(WebTrackerDBContext context) => _context = context;
        public bool AddFlowData(FlowData flowData)
        {
            _context.FlowDatas.Add(flowData);
            _context.SaveChanges();
            return true;
        }
        public bool DeleteFlowData(int id)
        {
            var flowdatas = _context.FlowDatas
                        .Where(x => x.FlowDataId == id)
                        .FirstOrDefault();
            if (flowdatas != null)
            {
                _context.FlowDatas.Remove(flowdatas);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public FlowData GetFlowDataById(int id)
        {
            return _context.FlowDatas.FirstOrDefault(a => a.FlowDataId == id);
        }

        public List<FlowData> GetAllFlowDatas()
        {
            return _context.FlowDatas.ToList();
        }

        public bool UpdateFlowData(int id, FlowData flowdatas)
        {
            var flowdataToUpdate = _context.FlowDatas.FirstOrDefault(a => a.FlowDataId == id);
            if (flowdataToUpdate != null)
            {
                flowdataToUpdate.Page = flowdatas.Page;
                flowdataToUpdate.FlowId = flowdatas.FlowId;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public List<FlowSum> flowSums(int loggedInUserWebsiteId)
        {
            List<FlowSum> flowSums = new List<FlowSum>();
            string con = @"Data Source=63.250.53.44;Initial Catalog=webtracker;User ID=ahmad;Password=ahmad@1234;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            string query = $"select [To], [From], [Count] from FlowCollectionSum where WebsiteID={loggedInUserWebsiteId}";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                FlowSum flow = new FlowSum();
                flow.From= dr[0].ToString();
                flow.To = dr[1].ToString();
                flow.Count = int.Parse(dr[2].ToString());
                flowSums.Add(flow);
            }
            return flowSums;
        }
        public List<ActionSum> actionSums(int loggedInUserWebsiteId)
        {
            List<ActionSum> actionSums = new List<ActionSum>();
            string con = @"Data Source=63.250.53.44;Initial Catalog=webtracker;User ID=ahmad;Password=ahmad@1234;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            string query = $"select [From-Type], [From-Content],[To-Type], [To-Content], [Count], [Page] from ActionCollectSum where WebsiteID={loggedInUserWebsiteId}";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ActionSum _action = new ActionSum();
                _action.fromType = dr[0].ToString();
                _action.fromContent = dr[1].ToString();
                _action.toType = dr[2].ToString();
                _action.toContent = dr[3].ToString();
                _action.Count = int.Parse(dr[4].ToString());
                _action.page = dr[5].ToString();
                
                actionSums.Add(_action);
            }
            return actionSums;
        }
    }
}