```
# Constants for estimation
TOKEN_COUNT = 128000
CHARS_PER_TOKEN = 4  # Common approximation for English text
TARGET_CHARS = TOKEN_COUNT * CHARS_PER_TOKEN

# Generate text
base_phrase = "This is a sample sentence for testing large token windows.\r\n "
repeats = (TARGET_CHARS // len(base_phrase)) + 1
generated_text = (base_phrase * repeats)[:TARGET_CHARS]

# Save to a file
with open("large_text_sample.txt", "w") as f:
    f.write(generated_text)

print(f"Generated a file with approximately {TOKEN_COUNT} tokens.")
print(f"Total character count: {len(generated_text)}")

```
