/*
 * Copyright (c) Contributors, http://virtual-planets.org/
 * See CONTRIBUTORS.TXT for a full list of copyright holders.
 * For an explanation of the license of each contributor and the content it 
 * covers please see the Licenses directory.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *       notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of the Virtual Universe Project nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE DEVELOPERS ``AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE CONTRIBUTORS BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Collections.Generic;
using System.Xml;
using OpenMetaverse;

namespace Universe.Framework.ClientInterfaces
{
    public class AvatarAnimations
    {
        public Dictionary<UUID, string> AnimStateNames = new Dictionary<UUID, string>();
        public Dictionary<string, UUID> AnimsUUID = new Dictionary<string, UUID>();

        public AvatarAnimations()
        {
            using (XmlTextReader reader = new XmlTextReader("data/avataranimations.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                foreach (XmlNode nod in doc.DocumentElement.ChildNodes)
                {
                    if (nod.Attributes["name"] != null)
                    {
                        string name = nod.Attributes["name"].Value;
                        UUID id = (UUID) nod.InnerText;
                        string animState = nod.Attributes["state"].Value;

                        try
                        {
                            AnimsUUID.Add(name, id);
                            if (animState != "" && !AnimStateNames.ContainsKey(id))
                                AnimStateNames.Add(id, animState);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
    }
}