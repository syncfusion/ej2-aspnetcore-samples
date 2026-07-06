using EJ2CoreSampleBrowser.Helpers.BrowserClasses;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

// <copyright file="HtmlTag.cs" company="Syncfusion Inc. 2001 - 2010.">
// All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
// </copyright>

namespace EJ2CoreSampleBrowser.Helpers.BrowserClasses
{
    /// <summary>
    /// Provides methods for render the Html elements
    /// </summary>
    public class HtmlTag
    {
        private readonly TagBuilder tagBuilder;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        public HtmlTag(string tagName)
            : this(tagName, TagRenderMode.Normal)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="renderMode">The render mode.</param>
        public HtmlTag(string tagName, TagRenderMode renderMode)
        {
            tagBuilder = new TagBuilder(tagName);
            ChildElements = new List<HtmlTag>();
            RenderMode = renderMode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <param name="configure">The configure.</param>
        public HtmlTag(string tagName, Action<HtmlTag> configure)
            : this(tagName)
        {
            configure(this);
        }

        /// <summary>
        /// Gets or sets the child elements.
        /// </summary>
        /// <value>The child elements.</value>
        public List<HtmlTag> ChildElements
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the template.
        /// </summary>
        /// <value>The template.</value>
        public Action<TextWriter> Template
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the render mode.
        /// </summary>
        /// <value>The render mode.</value>
        public TagRenderMode RenderMode
        {
            get;
            set;
        }

        /// <summary>
        /// Used to return Tags the name.
        /// </summary>
        /// <returns>TagName of the TagBuilder</returns>
        public string TagName()
        {
            return tagBuilder.TagName;
        }

        /// <summary>
        /// Used to set the ID attribute to Html element
        /// </summary>
        /// <param name="id">The element id.</param>
        /// <returns>HtmlTag</returns>
        public HtmlTag Id(string id)
        {
            Attributes("id", id);
            return this;
        }

        /// <summary>
        /// Adds the specified childs.
        /// </summary>
        /// <param name="childs">The childs.</param>
        /// <returns></returns>
        public HtmlTag Add(IEnumerable<HtmlTag> childs)
        {
            ChildElements.AddRange(childs);
            return this;
        }

        /// <summary>
        /// Adds the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public HtmlTag Add(string tag)
        {
            string[] tags = tag.Split('/');
            HtmlTag element = this;
            foreach (var el in tags)
            {
                var child = new HtmlTag(el);
                element.Add(child);
                element = child;
            }

            return element;
        }

        public HtmlTag AddTemplate(Action<TextWriter> template)
        {
            this.Template = template;
            return this;
        }
        /// <summary>
        /// Used to Add the specified child to the current instance.
        /// </summary>
        /// <param name="child">The child.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Add(HtmlTag child)
        {
            ChildElements.Add(child);
            return this;
        }

        /// <summary>
        /// Used to Add the specified child to the current instance and configure the child element.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="configure">The action.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Add(string tag, Action<HtmlTag> configure)
        {
            HtmlTag element = Add(tag);
            configure(element);
            return this;
        }

        /// <summary>
        /// Used to insert the child element to first position.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public void InsertFirst(HtmlTag tag)
        {
            ChildElements.Insert(0, tag);
        }

        /// <summary>
        /// Used to insert the child element to specified position.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="tag">The tag.</param>
        public void InsertAt(int index, HtmlTag tag)
        {
            ChildElements.Insert(index, tag);
        }

        /// <summary>
        /// Used to add the Childs the element to current instance.
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <returns></returns>
        public T ChildElement<T>() where T : HtmlTag, new()
        {
            var child = new T();
            ChildElements.Add(child);
            return child;
        }

        /// <summary>
        /// Used to Modifies the current instance
        /// </summary>
        /// <param name="configure">The Action.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Modify(Action<HtmlTag> configure)
        {
            configure(this);
            return this;
        }

        /// <summary>
        /// Used to get the First child element
        /// </summary>
        /// <returns>First child element</returns>
        public HtmlTag FirstChild()
        {
            return ChildElements.FirstOrDefault();
        }

        /// <summary>
        /// Attributeses this instance.
        /// </summary>
        /// <returns>attribute collection</returns>
        public IDictionary<string, string> Attributes()
        {
            return tagBuilder.Attributes;
        }

        /// <summary>
        /// Gets the attribute.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>attribute value</returns>
        public string GetAttribute(string key)
        {
            string value = null;
            Attributes().TryGetValue(key, out value);
            return value;
        }

        /// <summary>
        /// Attributeses the specified attributes.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Attributes(object attributes)
        {
            Attributes<string, object>(new RouteValueDictionary(attributes));
            return this;
        }

        /// <summary>
        /// Attributeses the specified attributes.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributes">The attributes.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Attributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            Attributes(attributes, true);
            return this;
        }

        /// <summary>
        /// Adds an attribute to the specified collection of attributes for the tag
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributes">The attributes.</param>
        /// <param name="replaceExisting">if set to <c>true</c> [replace existing].</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Attributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
        {
            tagBuilder.MergeAttributes(attributes, replaceExisting);
            return this;
        }


        /// <summary>
        ///  Adds an attribute to the tag by using the specified key/value pair.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Attributes(string key, string value)
        {
            Attributes(key, value, true);
            return this;
        }

        /// <summary>
        /// Adds an attribute to the tag by using the specified key/value pair
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="replaceExisting">if set to <c>true</c> [replace existing].</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Attributes(string key, string value, bool replaceExisting)
        {
            tagBuilder.MergeAttribute(key, value, replaceExisting);
            return this;
        }

        /// <summary>
        /// Adds the specified CSS class to the tag-builder attributes.
        /// </summary>
        /// <param name="className">Name of the class.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag AddClass(string className)
        {
            if (className.Contains(" "))
            {
                throw new ArgumentException("Css Class name should not contains spaces.");
            }

            if (Attributes().ContainsKey("class"))
            {
                string cssclass = Attributes()["class"];
                Attributes()["class"] = cssclass + " " + className;
            }
            else
            {
                Attributes()["class"] = className;
            }

            return this;
        }

        /// <summary>
        /// Adds the array of  CSS classes to the tag-builder attributes
        /// </summary>
        /// <param name="classes">The classes.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag AddClasses(params string[] classes)
        {
            var _cssclass = classes[0].Split(' ');
            foreach (string c in _cssclass)
            {
                AddClass(c);
            }

            return this;
        }

        /// <summary>
        /// Adds the list of  CSS classes to the tag-builder attributes
        /// </summary>
        /// <param name="classes">The classes.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag AddClasses(List<string> classes)
        {
            AddClasses(classes.ToArray());
            return this;
        }

        /// <summary>
        /// Styles the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HtmlTag Style(string key, string value)
        {
            if (Attributes().ContainsKey("style"))
            {
                string style = Attributes()["style"];
                Attributes()["style"] = style + ";" + key + ":" + value;
            }
            else
            {
                Attributes()["style"] = key + ":" + value;
            }

            return this;
        }

        /// <summary>
        /// Hides this instance.
        /// </summary>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Hide()
        {
            return Style("display", "none");
        }

        /// <summary>
        /// HTMLs the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Html(string value)
        {
            tagBuilder.InnerHtml = value;
            ChildElements.Clear();
            return this;
        }

        /// <summary>
        /// Prepends the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Prepend(string text)
        {
            tagBuilder.InnerHtml = text + tagBuilder.InnerHtml;
            ChildElements.Clear();
            return this;
        }

        /// <summary>
        /// Texts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Current HtmlTag instance</returns>
        public HtmlTag Text(string value)
        {
            tagBuilder.SetInnerText(value);
            ChildElements.Clear();
            return this;
        }

        /// <summary>
        /// Gets the inner HTML.
        /// </summary>
        /// <returns></returns>
        public string GetInnerHtml()
        {
            return tagBuilder.InnerHtml;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            using (StringWriter output = new StringWriter(CultureInfo.CurrentCulture))
            {
                Render(output);
                return output.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Renders the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void Render(TextWriter writer)
        {
            if (RenderMode != TagRenderMode.SelfClosing)
            {
                writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));

                if (Template != null)
                {
                    Template(writer);
                }
                if (ChildElements.Any())
                {
                    ChildElements.ForEach(child => child.Render(writer));
                }
                else
                {
                    writer.Write(tagBuilder.InnerHtml);
                }

                writer.Write(tagBuilder.ToString(TagRenderMode.EndTag));
            }
            else
            {
                writer.Write(tagBuilder.ToString(TagRenderMode.SelfClosing));
            }
        }
    }
}
