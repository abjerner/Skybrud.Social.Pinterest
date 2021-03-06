﻿using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Pinterest.Fields;

namespace Skybrud.Social.Pinterest.Options.Boards {

    /// <summary>
    /// Class with options for a request to the Pinterest API for getting information about a single Pinterest board.
    /// </summary>
    public class PinterestGetBoardOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or set the identifier of the board to be retrieved.
        /// </summary>
        public string Board { get; set; }

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
        /// Initializes the options based on the specified <paramref name="board"/>.
        /// </summary>
        /// <param name="board">The identifier of the board to be retrived.</param>
        public PinterestGetBoardOptions(string board) : this() {
            Board = board;
        }

        /// <summary>
        /// Initializes the options based on the specified <paramref name="board"/> and <paramref name="fields"/>.
        /// </summary>
        /// <param name="board">The identifier of the board to be retrived.</param>
        /// <param name="fields">A collection of the fields that should be returned.</param>
        public PinterestGetBoardOptions(string board, PinterestFieldsCollection fields) {
            Board = board;
            Fields = fields ?? new PinterestFieldsCollection();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            
            // Convert the collection of fields to a string
            string fields = (Fields == null ? "" : Fields.ToString()).Trim();

            // Construct the query string
            SocialHttpQueryString query = new SocialHttpQueryString();
            if (!String.IsNullOrWhiteSpace(fields)) query.Set("fields", fields);

            return query;

        }

        #endregion

    }

}