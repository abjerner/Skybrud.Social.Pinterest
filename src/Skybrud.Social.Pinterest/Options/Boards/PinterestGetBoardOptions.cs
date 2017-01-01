﻿using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Pinterest.Fields;

namespace Skybrud.Social.Pinterest.Options.Boards {
    
    public class PinterestGetBoardOptions : IHttpGetOptions {

        #region Constructors

        /// <summary>
        /// Gets or set the name of the board.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the board.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the fields to be returned.
        /// </summary>
        public PinterestFieldsCollection Fields { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public PinterestGetBoardOptions() {
            Fields = new PinterestFieldsCollection();
        }

        /// <summary>
        /// Initializes the options based on the specified <paramref name="name"/> and <paramref name="description"/>.
        /// </summary>
        /// <param name="name">The name of the board to be created.</param>
        /// <param name="description">The description of the board to be created.</param>
        public PinterestGetBoardOptions(string name, string description) : this() {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Initializes the options based on the specified <paramref name="name"/>, <paramref name="description"/> and
        /// <paramref name="fields"/>.
        /// </summary>
        /// <param name="name">The name of the board to be created.</param>
        /// <param name="description">The description of the board to be created.</param>
        /// <param name="fields">A collection of the fields that should be returned.</param>
        public PinterestGetBoardOptions(string name, string description, PinterestFieldsCollection fields) {
            Name = name;
            Description = description;
            Fields = fields ?? new PinterestFieldsCollection();
        }

        #endregion

        public IHttpQueryString GetQueryString() {

            // Since the name is mandatory, we throw an exception if no specified
            if (String.IsNullOrWhiteSpace(Name)) throw new PropertyNotSetException("Name");
            
            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            SocialHttpQueryString query = new SocialHttpQueryString();
            query.Add("name", Name);
            if (!String.IsNullOrWhiteSpace(Description)) query.Add("description", Description);
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }
    
    }

}