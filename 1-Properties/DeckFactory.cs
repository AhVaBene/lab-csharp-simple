namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;

        private string[] _names;

        // TODO improve
        public IList<string> Seeds
        {
            get { return _seeds.ToList(); }
            set { _seeds = value.ToArray(); }
        }

        /*public IList<string> GetSeeds()
        {
            return this.seeds.ToList();
        }
        public void SetSeeds(IList<string> seeds)
        {
            this.seeds = seeds.ToArray();
        }
        */

        // TODO improve
        public IList<string> Names
        {
            get { return _names.ToList(); }
            set { _names = value.ToArray(); }
        }

        /*
        public IList<string> GetNames()
        {
            return this.names.ToList();
        }
        public void SetNames(IList<string> names)
        {
            this.names = names.ToArray();
        }
        */
        // TODO improve
        public int GetDeckSize() => _names.Length * _seeds.Length;

        /// TODO improve
        public ISet<Card> Deck
        {
            get
            {
                if (_names == null || _seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, _names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, _seeds.Length)
                        .Zip(
                            Enumerable.Range(0, _seeds.Length),
                            (n, s) => Tuple.Create(_names[n], _seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}
