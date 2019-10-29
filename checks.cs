namespace Beadando_Forms {
	public class checks {
		public bool isAlphaNum (string s) {
			if (string.IsNullOrEmpty (s) || string.IsNullOrWhiteSpace (s))
				return false;
			for (int i = 0; i < s.Length; i++) {
				if (!(char.IsLetterOrDigit (s[i])))
					return false;
			}
			return true;
		}
	}
}
