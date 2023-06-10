using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameServerSelector.Requests
{
	public class Query
	{
		[JsonProperty("field")]
		public string Field { get; set; }
		[JsonProperty("query")]
		public QueryData QueryData { get; set; }
	}
	

	public class QueryData
	{
		[JsonProperty("operator")]
		public string Operator { get; set; }
		[JsonProperty("value")]
		public object Value { get; set; }
	}

	
	public class SearchServerRequest
	{
		private List<Query> queries;
		
		public static readonly string Equal = "eq";
		public static readonly string In = "in";
		public static readonly string Match = "match";
		public static readonly string GreaterThan = "gt";
		public static readonly string LessThan = "lt";
		public static readonly string GreaterThanOrEqual = "gte";
		public static readonly string LessThanOrEqual = "lte";
		public static readonly string NotEqual = "neq";


		public SearchServerRequest()
		{
			queries = new List<Query>();
		}
		
		public SearchServerRequest AddMatchQuery(string field, string value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = Match,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddInQuery(string field, List<string> value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = In,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddGreaterThanQuery(string field, Int64 value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = GreaterThan,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddLessThanQuery(string field, Int64 value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = LessThan,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddLessThanOrEqualQuery(string field, Int64 value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = LessThanOrEqual,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddGreaterThanOrEqualQuery(string field, Int64 value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = GreaterThanOrEqual,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		
		public SearchServerRequest AddEqualQuery(string field, Int64 value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = Equal,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		private SearchServerRequest AddQuery(string field, string queryOperator, object value)
		{
			var query = new Query
			{
				Field = field,
				QueryData = new QueryData
				{
					Operator = queryOperator,
					Value = value
				}
			};

			queries.Add(query);
			return this;
		}
		

		public string ToJsonString()
		{
			return JsonConvert.SerializeObject(queries);
		}
	}
}
